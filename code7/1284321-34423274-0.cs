    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENMAME = @"c:\temp\test.txt";
            enum State
            {
                FIND_HEY,
                GET_DATA,
                FOUND_QUESTION
            }
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENMAME);
                string inputline = "";
                State state = State.FIND_HEY;
                while ((inputline = reader.ReadLine()) != null)
                {
                    inputline = inputline.Trim();
                    if (inputline.Count() > 0)
                    {
                        switch (state)
                        {
                            case State.FIND_HEY :
                                if(inputline.ToUpper().Contains("HEY"))
                                {
                                    state = State.GET_DATA;
                                }
                                break;
                            case State.GET_DATA :
                                if(inputline.ToUpper().Contains("QUESTION"))
                                {
                                    state = State.FOUND_QUESTION;
                                }
                                else
                                {
                                    Console.WriteLine(inputline);
                                }
                                break;
                            case State.FOUND_QUESTION :
                                break;
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
    ​
