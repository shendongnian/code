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
                        "14:22 RUN\n" +
                             "- abc\n" +
                             "- bfg\n" +
                                 "dmf\n" +
                                    "-rkc\n" +
                        "15:33\n" +
                             "dbv\n" +
                                "-fjh\n" +
                                "-fjs\n";
                StringReader reader = new StringReader(input);
                string inputLine = "";
                string output = "";
                State state = State.FIND_START;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    switch (state)
                    {
                        case State.FIND_START:
                            if (inputLine.Contains("RUN"))
                            {
                                output += inputLine + "\n";
                                state = State.COLLECT_DATA;
                            }
                            break;
                        case State.COLLECT_DATA:
                            output += inputLine + "\n";
                            if (inputLine == "dbv") state = State.STOP_COLLECTING;
                            break;
                        case State.STOP_COLLECTING:
                            break;
                    }
                }
            }
        }
    }
