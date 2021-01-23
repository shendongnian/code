    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            public enum State
            {
                FIND_BEGIN,
                FIND_END
            }
            static void Main(string[] args)
            {
                string input =
                    "BEGIN:VNOTE\n" +
                    "VERSION:1.1\n" +
                    "BODY;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:Penguins are among the most popular of all birds. They only live in and around the South Pole and the continent of Antarctica.No wild penguins live at the North Pole. There are many different kinds of penguins. The largest penguin is called the Emperor Penguin, and the smallest kind of penguin is the Little Blue Penguin. There are 17 different kinds of penguins in all, and none of them can fly\n";
                StringReader reader = new StringReader(input);
                StringBuilder builder = new StringBuilder();
                StringWriter writer = new StringWriter(builder);
                State state = State.FIND_BEGIN;
                string inputLine = "";
                Boolean end = false;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    switch (state)
                    {
                        case State.FIND_BEGIN :
                            if(inputLine.StartsWith("BEGIN:"))
                            {
                                writer.WriteLine(inputLine);
                                state = State.FIND_END;
                            }
                            break;
                        case State.FIND_END :
                            if (inputLine.StartsWith("BODY;"))
                            {
                                writer.WriteLine(inputLine.Substring(0, inputLine.IndexOf(":") + 1));
                                end = true;
                            }
                            else
                            {
                                writer.WriteLine(inputLine);
                            }
                            break;
                    }
                    if (end) break;
                }
                string output = builder.ToString();
                
            }
        }
    }
