    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            enum State
            {
                FIND_ID,
                FIND_VALUE
            }
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                List<A> a_s = new List<A>();
                string inputLine = "";
                StreamReader reader = new StreamReader(FILENAME);
                State state = State.FIND_ID;
                A a = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (!inputLine.StartsWith("-") || inputLine.Length > 0)
                    {
                        switch (state)
                        {
                            case State.FIND_ID :
                                if (inputLine.StartsWith("Id"))
                                {
                                    string[] inputArray = inputLine.Split(new char[] { ':' });
                                    a = new A();
                                    a_s.Add(a);
                                    a.Id = inputArray[1].Trim();
                                    state = State.FIND_VALUE;
                                }
                                break;
                            case State.FIND_VALUE:
                                if (inputLine.StartsWith("Value"))
                                {
                                    string[] inputArray = inputLine.Split(new char[] { ':' });
                                    a.Value = inputArray[1].Trim();
                                    state = State.FIND_ID;
                                }
                                break;
                        }
                    }
                }
            }
        }
        class A
        {
            public string Id { get; set; }
            public string Value { get; set; }
        }
    }
    ​
