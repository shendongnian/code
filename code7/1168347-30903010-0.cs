    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace Program
    {
      public class TransformCsv
      {
        [STAThread]
        public static void Main(String[] args)
        {
          (new TransformCsv()).Run(@"c:\temp\MessExport_20110402_0000.csv", @"c:\temp\output.txt", LineFilterFunction);
        }
        public static Boolean LineFilterFunction(String line)
        {
          return line.Contains("M40") || line.Contains("M08");
        }
        ////////////////////
        private List<String> _dayOfWeek = new List<String>() { "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
        private Dictionary<String, String> _mReference =
          new Dictionary<String, String>()
          {
            // Add other M-reference mappings here.
            { "M40", "2" },
            { "M08", "3" },
            { "M20", "3" }
          };
        public void Run(String inputFilePath, String outputFilePath, Func<String, Boolean> lineFilterFunction)
        {
          using (var reader = new StreamReader(inputFilePath))
          {
            using (var writer = new StreamWriter(outputFilePath))
            {
              String line = null;
              while ((line = reader.ReadLine()) != null)
              {
                if (!String.IsNullOrWhiteSpace(line) && lineFilterFunction(line))
                  writer.WriteLine(this.GetTransformedLine(line));
              }
            }
          }
        }
        private static Char[] _spaceCharacter = " ".ToCharArray();
        private String GetTransformedLine(String line)
        {
          var elements = line.Split(_spaceCharacter, StringSplitOptions.RemoveEmptyEntries);
          var result = new List<String>();
          result.Add((_dayOfWeek.IndexOf(elements[0]) + 1).ToString());
          result.Add(elements[1].Replace(':', ','));
          result.Add(_mReference[elements[2]]);
          result.AddRange(elements.Skip(3).Where(e => this.IsInt32(e)));
          return String.Join(",", result);
        }
        private Boolean IsInt32(String s)
        {
          Int32 _;
          return Int32.TryParse(s, out _);
        }
      }
    }
