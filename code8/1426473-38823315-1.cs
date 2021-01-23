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
                Course course = new Course();
                course.ReadXML(FILENAME);
            }
        }
        public class Course
        {
            public static List<Course> courses = new List<Course>(); 
            public int id { get; set; }
            public string shortname { get; set; }  //short name of course
            public string fullname { get; set; }   //long name of course
            public int enrolledusercount { get; set; }  //Number of enrolled users in this course
            public string idnumber { get; set; }   //id number of course
            public int visible { get; set; }  //1 means visible, 0 means hidden course
            public string summary { get; set; }
            public int summaryformat { get; set; } //summary format (1 = HTML, 0 = MOODLE, 2 = PLAIN or 4 = MARKDOWN)
            public string format { get; set; } //course format: weeks, topics, social, site
            public int showgrades { get; set; } //true if grades are shown, otherwise false
            public string lang { get; set; } //forced course language
            public int enablecompletion { get; set; } //true if completion is enabled, otherwise false
            public void ReadXML(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                courses = doc.Descendants("SINGLE").Select(x => ReadKeys(x)).ToList();
            }
            public Course ReadKeys(XElement single)
            {
                Course newCourse = new Course();
                foreach(XElement key in single.Descendants("KEY"))
                {
                    switch(key.Attribute("name").Value)
                    {
                        case "id" :
                            newCourse.id = (int)key.Element("VALUE");
                            break;
                    }
                }
                return newCourse;
            }
        }
    }
