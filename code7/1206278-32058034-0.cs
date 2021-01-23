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
                FIND_START,
                COLLECT_DATA,
                STOP_COLLECTING
            }
            static void Main(string[] args)
            {
                string input =
                        "f\n" +
                        "hj\n" +
                    "13:45\n" +
                        "A\n" +
                        "Cd\n" +
                        "F\n" +
                        "RT\n" +
                    "14:10\n" +
                        "df\n" +
                        "gj\n" +
                        "G\n";
                StringReader reader = new StringReader(input);
                string inputLine = "";
                string output = "";
                State state = State.FIND_START;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    switch (state)
                    {
                        case State.FIND_START :
                            if (inputLine == "hj") state = State.COLLECT_DATA;
                            break;
                        case State.COLLECT_DATA:
                            output += inputLine + "\n";
                            if (inputLine == "gj") state = State.STOP_COLLECTING;
                            break;
                        case State.STOP_COLLECTING :
                            break;
                    }
                }
            }
        }
    }
    ​
