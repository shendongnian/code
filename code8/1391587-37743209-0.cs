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
            enum State
            {
                FIND_HEADINGBEGIN,
                HEADINGBEGIN,
                EMPLOYEE,
                FIND_GROUPBEGIN,
                GROUP
            }
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                State state = State.FIND_HEADINGBEGIN;
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement xLine in doc.Descendants("Line"))
                {
                    string line = ((string)xLine).Trim();
                    if (line.Length > 0)
                    {
                        switch(state)
                        {
                            case State.FIND_HEADINGBEGIN :
                                if (line.StartsWith("#HEADINGBEGIN#"))
                                {
                                    state = State.HEADINGBEGIN;
                                }
                                else
                                {
                                }
                                break;
                            case State.HEADINGBEGIN :
                                if (line.StartsWith("#HEADINGEND#"))
                                {
                                    state = State.EMPLOYEE;
                                }
                                else
                                {
                                }
                                break;
                            case State.EMPLOYEE:
                                if (line.StartsWith("#GROUPNOBREAK#"))
                                {
                                    state = State.FIND_GROUPBEGIN;
                                }
                                else
                                {
                                }
                                break;
                            case State.FIND_GROUPBEGIN:
                                if (line.StartsWith("#GROUPBEGIN#"))
                                {
                                    state = State.GROUP;
                                }
                                break;
                            case State.GROUP :
                                if (line.StartsWith("#GROUPEND#"))
                                {
                                    state = State.FIND_HEADINGBEGIN;
                                }
                                else
                                {
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
