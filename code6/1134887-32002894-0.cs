    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Office.Interop.Word;
    using Microsoft.Office.Interop.Excel;
    using System.IO;
    namespace ConsoleApplication2
    {
    class Program
    {
        static void Main(string[] args)
        {
            string month = "July2014";
            string delimiter = ",";
            string[] files = Directory.GetFiles("C:\\temp\\"+ month);
            string[][] csvoutput = new string[][] { };
            csvoutput = new string[][] { new string[]{"School Name","Student Name","Id","ReportDate"}};
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(delimiter, csvoutput[0]));
            File.AppendAllText("C:\\Temp\\"+month+".csv", sb.ToString());
            foreach (var file in files)
            {
                var id = string.Empty;
                var studentName = string.Empty;
                var school = string.Empty;
                var reportDate = string.Empty;
                if (file.ToLower().EndsWith(".doc"))
                {
                    var word = new Microsoft.Office.Interop.Word.Application();
                    var sourceFile = new FileInfo(file);
                    var doc = word.Documents.Open(sourceFile.FullName);
                    Console.WriteLine("Processing :-{ " + file.ToLower());
                    for (int i = 0; i < doc.Paragraphs.Count; i++)
                    {
                        
                        try
                        {
                            if (doc.Paragraphs[i + 1].Range.Text.StartsWith("School:"))
                            {
                                school = doc.Paragraphs[i + 1].Range.Text.ToString().Replace("\r\a","").Replace("School: ","").Trim();
                                
                            }
                            if (doc.Paragraphs[i + 1].Range.Text.StartsWith("Student Names:"))
                            {
                                studentName = doc.Paragraphs[i + 1].Range.Text.ToString().Replace("\r\a", "").Replace("Student Names:","").Trim();
                                
                            }
                            if (doc.Paragraphs[i + 1].Range.Text.StartsWith("xx Id:"))
                            {
                                id = doc.Paragraphs[i + 1].Range.Text.ToString().Replace("\r\a", "").Replace("xx Id:", "").Trim();
                                
                            }
                            if (doc.Paragraphs[i + 1].Range.Text.StartsWith("Date of Report:"))
                            {
                                reportDate = doc.Paragraphs[i + 1].Range.Text.ToString().Replace("\r\a", "").Replace("Date of Report:","").Trim();
                               
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error occurred" + file.ToLower());
                        }
                    }
                    csvoutput = new string[][]
                            {
                                new string[]{school,studentName,id,reportDate} 
                            };
                    int csvlength = csvoutput.GetLength(0);
                    for (int index = 0; index < csvlength; index++)
                        sb.AppendLine(string.Join(delimiter, csvoutput[index]));
                    File.AppendAllText("C:\\Temp\\" + month + ".csv", sb.ToString());
                    word.ActiveDocument.Close();
                    word.Quit();
                }
            }
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
