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
                FIND_ONMAP,
                FIND_RETURN,
                DONE
            }
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                List<byte> onmap = Encoding.UTF8.GetBytes("ONMAP").ToList();
                FileStream stream = File.OpenRead(FILENAME);
                int data = 0;
                State state = State.FIND_ONMAP;
                List<byte> buffer = new List<byte>();
                while ((data = stream.ReadByte()) != -1)
                {
                    switch (state)
                    {
                        case State.FIND_ONMAP:
                            if (buffer.Count < 5)
                            {
                                buffer.Add((byte)(data & 0xff));
                            }
                            else
                            {
                                buffer.RemoveAt(0);
                                buffer.Add((byte)(data & 0xff));
                            }
                            if (buffer.SequenceEqual(onmap))
                            {
                                state = State.FIND_RETURN;
                            }
                            break;
                        case State.FIND_RETURN:
                            if (data == 10)
                            {
                                state = State.DONE;
                                break;
                            }
                            else
                            {
                                buffer.Add((byte)(data & 0xff));
                            }
                            break;
                    }
                    if (state == State.DONE) break;
                }
                if (state == State.DONE)
                {
                    string results = Encoding.UTF8.GetString(buffer.ToArray());
                    Console.WriteLine(results);
                    Console.ReadLine();
                }
                
            }
        }
    }
    ​
