    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace ExtensionExtractingTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string fileNames = "test.docxtest2.txttest3.pdftest.test.xlxtest.docxtest2.txttest3.pdftest.test.xlxtest.docxtest2.txttest3.pdftest.test.xlxourtest.txtnewtest.pdfstackoverflow.pdf";
                Regex fileNameMatchRegex = new Regex(@"[a-zA-Z0-9]*(\.txt|\.pdf|\.docx|\.txt|\.xlx)", RegexOptions.IgnoreCase);
                MatchCollection matchResult = fileNameMatchRegex.Matches(fileNames);
                List<string> fileNamesList = new List<string>();
                foreach (Match item in matchResult)
                {
                    fileNamesList.Add(item.Value);
                }
                fileNamesList = fileNamesList.Distinct().ToList();
                Console.WriteLine(string.Join(";", fileNamesList));
            }
        }
    }
