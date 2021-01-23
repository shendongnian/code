    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                BusinessEntities be = new BusinessEntities();
                be.Parse(FILENAME);
            }
        }
        public class BusinessEntities
        {
            public enum FileParseResultType
            {
                ValidFileClaim
            }
            public class FileParseResult
            {
                public FileParseResultType FileParseResultType { get; set; }
            }
            public BusinessEntities.FileParseResult Parse(string FilePath)
            {
                FileParseResult _fileParseResult = new FileParseResult();
                _fileParseResult.FileParseResultType = FileParseResultType.ValidFileClaim;
                //Logger.LogMessage(PREPROCESS_FILEPARSER.TRACE_MSG, "****WorkComp.Net : Pre Processor -> Start parsing valid AT XML File *****");
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                using (XmlReader reader = XmlReader.Create(FilePath, settings))
                {
                    try
                    {
                        string tranmissionsattr = string.Empty;
                        string header = string.Empty;
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name.ToLower() == "transmissions")
                            {
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    tranmissionsattr = tranmissionsattr + "  " + reader.Name + "=\"" + reader.GetAttribute(i) + "\"";
                                }
                                reader.MoveToElement();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
                return _fileParseResult;
            }
        }
    }
    ​
