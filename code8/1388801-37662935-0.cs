    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var root = doc.Elements("RootData").Select(x => new
                {
                    passResults = x.Elements("PassResult").Select(y => new
                    {
                        firstOne = (string)y.Element("FirstOne"),
                        secondOne = (string)y.Element("SecondOne"),
                        isMale = (Boolean)y.Element("IsMale")
                    }).FirstOrDefault(),
                    testResult = x.Elements("TestResult").Select(y => new {
                        markOne = (int)y.Element("MarkOne"),
                        markTwo = (int)y.Element("MarkTwo"),
                        slope = (int)y.Element("Slope")
                    }).FirstOrDefault(),
                    toneTestResult = x.Elements("ToneTestResult").Select(y => new {
                        totalTime = (int)y.Element("TotalTime"),
                        correctPecentage = (int)y.Element("CorrectPercentage")
                    }).FirstOrDefault(),
                    questionnaireResult = x.Elements("QuestionnaireResult").Elements("Question").Select(y => new {
                        question = (int)y.Attribute("Id"),
                        answer = (string)y.Descendants("Answer").FirstOrDefault().Attribute("Id")
                    }).ToList(),
                }).FirstOrDefault();
            }
        }
    }
