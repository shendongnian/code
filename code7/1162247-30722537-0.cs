    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.IO;
    namespace ConsoleApplication33
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = 
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                    "<TestSettings name=\"Settings\" id=\"6f67be45-4967-40c3-a89f7665cc7f654e2\" xmlns=\"http://microsoft.com/schemas/VisualStudio/TeamTest/2010\">\n" +
                      "<Description>These are default test settings for a local test run.</Description>\n" +
                      "<Deployment>\n" +
                    "<DeploymentItem filename=\"TestCaseXml\\LTestCases.xml\" />\n" +
                    "<DeploymentItem filename=\"..\\..\\Framework\\Common\\Xmls\\TestSuite.xml\" />\n" +
                    "<DeploymentItem filename=\"TestCaseXml\\bTestCases.xml\" />\n" +
                    "<DeploymentItem filename=\"TestCaseXml\\PTestCases.xml\" />\n" +
                    "<DeploymentItem filename=\"TestCaseXml\\1TestCases.xml\" />\n" +
                    "</Deployment>\n" +
                    "</TestSettings>\n";
                string defaultItems =
                    "<DeploymentItem xmlns=\"\">filename='Scripts\'</DeploymentItem>\n" +
                    "<DeploymentItem xmlns=\"\">filename='TestCaseXml\\TestCases.xml'</DeploymentItem>\n" +
                    "<DeploymentItem xmlns=\"\">filename='Xmls\\TestSuite.xml'</DeploymentItem>\n";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(input);
                XmlNode deployment = doc.GetElementsByTagName("Deployment")[0];
                deployment.RemoveAll();
                deployment.InnerXml = defaultItems;
     
            }
        }
    }
