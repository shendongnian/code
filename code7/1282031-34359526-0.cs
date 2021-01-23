        using Microsoft.VisualStudio.TestTools.UnitTesting;
        using System.Text.RegularExpressions;
        using DocumentFormat.OpenXml.Packaging;
        namespace UnitTestProject1
        {
            [TestClass]
            public class UnitTest1
            {
                [TestMethod]
                public void TestMethod1()
                {           
                    SearchAndReplace(@"C:\TestDoc\testdoc1.docx");
                }
                public static void SearchAndReplace(string document)
                {
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
                    {
                        string docText = null;
                        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }
                        Regex regexText = new Regex("Hello world!");
                        docText = regexText.Replace(docText, "Hi Everyone!");
                        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }
                    }
                }
            }
        }
