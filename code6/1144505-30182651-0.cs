    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using iTextSharp.text.pdf;
    namespace ARRL_Book_Compiler
    {
        internal class Program
        {
            private const string ACTION_KEY = "Action";
            private const string FILE_KEY = "File";
            private const string KIDS_KEY = "Kids";
            private const string PAGE_KEY = "Page";
            private const char DELIM = ' ';
            private static void Main(string[] args)
        {
            if (args.Count() != 2)
            {
                Console.WriteLine("Arg 1: PDF directory");
                Console.WriteLine("Arg 2: Output filename");
                Environment.Exit(1);
            }
            Merge(args[0], args[1]);
        }
        /// <summary>
        /// Compiles ARRL books.
        /// </summary>
        /// <param name="folder">Directory containing all the PDFs in the entire book.</param>
        /// <param name="output">Path and filename of the output (compiled) PDF.</param>
        private static void Merge(string folder, string output)
        {
            int offset = 1;  // Setting to 0 causes all bookmarks to be off by 1
            string[] dirFiles
                = Directory.GetFiles(folder).Where(f => f.EndsWith("pdf")).ToArray();  // PDFs in directory
            IList<Dictionary<string, object>> oldBookmarks
                = SimpleBookmark.GetBookmark(new PdfReader(dirFiles[0]));
            List<Dictionary<string, object>> newBookmarks = new List<Dictionary<string, object>>();
            FileStream outFile = new FileStream(output, FileMode.Create);
            PdfConcatenate newPdf = new PdfConcatenate(outFile);
            if (oldBookmarks.Count() == 1)
            {
                oldBookmarks = (IList<Dictionary<string, object>>)(oldBookmarks[0])[KIDS_KEY];
            }
            string[] bFiles
                = oldBookmarks.Select(b => b[FILE_KEY]).Cast<string>().ToArray();  // get files in bookmark order
            IEnumerable<string> missingFiles = bFiles.Except(dirFiles.Select(f => Path.GetFileName(f)));
            if (missingFiles.Any())
            {
                Console.Error.WriteLine("The following files are present in the bookmarks but not in the directory:");
                foreach (string filename in missingFiles) Console.Error.WriteLine(filename);
                Environment.Exit(2);
            }
            for(int i = 0; i < bFiles.Count(); i++)
            {
                Console.Write(string.Format("\r{0}% complete", (int)((i + 1f)/bFiles.Count()*100)));
                string filename = bFiles[i];
                PdfReader reader = new PdfReader(Path.Combine(folder, filename));
                List<Dictionary<string, object>> tempBookmarks =
                    oldBookmarks.Where(b => b.ContainsKey(FILE_KEY) && (string)b[FILE_KEY] == filename).ToList();
                // handles bookmarks
                newBookmarks.AddRange(ModifyBookmarks(  // Exception if LINQ can't find FILE_KEY key in ANY list item
                    oldBookmarks.Where(b => b.ContainsKey(FILE_KEY) && (string)b[FILE_KEY] == filename).ToList(),
                    offset));
                offset += reader.NumberOfPages;
                newPdf.AddPages(reader);
                reader.Close();
            }
            newPdf.Writer.Outlines = newBookmarks;
            newPdf.Close();
        }
        private static List<Dictionary<string, object>>
            ModifyBookmarks(List<Dictionary<string, object>> list, int offset)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                string pageKey = (string)list[i][PAGE_KEY];
                int index = pageKey.IndexOf(DELIM);
                list[i][PAGE_KEY] = (int.Parse(pageKey.Substring(0, index)) + offset).ToString()
                    + pageKey.Substring(index);
                if (list[i].ContainsKey(FILE_KEY)) list[i].Remove(FILE_KEY);
                if (list[i].ContainsKey(ACTION_KEY)) list[i][ACTION_KEY] = "GoTo";
                if (list[i].ContainsKey(KIDS_KEY))
                    list[i][KIDS_KEY] = ModifyBookmarks((List<Dictionary<string, object>>)list[i][KIDS_KEY], offset);
            }
            return list;
        }
    }
    }
