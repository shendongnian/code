    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Threading.Tasks;
    namespace ReadWriteTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string filePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    "Test.xml");
            
                string result = CreateAndSave(new string[] { "Hello", "World", "!" }, filePath);
                Console.WriteLine("============== FIRST PASS ==============");
                Console.WriteLine(result);
                result = CreateAndSave(new string[] { "Hello", "World", "AGAIN", "!" }, filePath);
                Console.WriteLine("============== SECOND PASS ==============");
                Console.WriteLine(result);
                Console.ReadLine();
            }
            public static string CreateAndSave(IEnumerable<string> orderPages, string filePath)
            {
                if (orderPages == null || !orderPages.Any())
                {
                    return string.Empty;
                }
                var xmlBuilder = new StringBuilder();
                var writerSettings = new XmlWriterSettings
                {
                    Indent = true,
                    Encoding = Encoding.GetEncoding("ISO-8859-1"),
                    CheckCharacters = false,
                    ConformanceLevel = ConformanceLevel.Document
                };
                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    try
                    {
                        XmlWriter xmlWriter = XmlWriter.Create(fs, writerSettings);
                        xmlWriter.WriteStartElement("PRINT_JOB");
                        foreach (var page in orderPages)
                        {
                            xmlWriter.WriteElementString("PAGE", page);
                        }
                        xmlWriter.WriteFullEndElement();
                        xmlWriter.Flush();  // Flush from xmlWriter to fs
                        xmlWriter.Close();
                        fs.Seek(0, SeekOrigin.Begin); // Go back to read from the begining
                        MemoryStream destination = new MemoryStream();
                        fs.CopyTo(destination);
                        xmlBuilder.Append(Encoding.UTF8.GetString(destination.ToArray()));
                        destination.Flush();
                        destination.Close();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    fs.Flush();
                    fs.Close();
                }
                return xmlBuilder.ToString();
            }
        }
    }
