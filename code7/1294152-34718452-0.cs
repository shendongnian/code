    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Parse parse = new Parse(FILENAME);
                List<object> results = parse.Recursion();
            }
        }
        public class Parse
        {
            enum State
            {
                NOTHING,
                GET_NAME,
                GET_VALUE
            }
            static StreamReader reader = null;
            public Parse(string filename)
            {
                reader = new StreamReader(filename);
                
            }
            public List<object> Recursion()
            {
                List<object> results = new List<object>();
                char[] chr = new  char[1];
                State state = State.NOTHING;
                Boolean exit = false;
                Boolean openDoubleQuote = false;
                string name = "";
                string value = "";
                while(reader.Read(chr, 0, 1) == 1)
                {
                    switch (state)
                    {
                        case State.NOTHING :
                            switch(chr[0])
                            {
                                case '{' :
                                    results.Add(Recursion());                     
                                    break;
                                case '\"':
                                    state = State.GET_NAME;
                                    openDoubleQuote = true;
                                    break;
                            }
                            break;
                        case State.GET_NAME:
                            switch(chr[0])
                            {
                                case '\"' :
                                    if (openDoubleQuote == false)
                                    {
                                        openDoubleQuote = true;
                                    }
                                    else
                                    {
                                        state = State.GET_VALUE;
                                        openDoubleQuote = false;
                                    }
                                    break;
                                case '}' :
                                    exit = true;
                                    break;
                                default : 
                           
                                    if (openDoubleQuote == true)
                                    {
                                        name += chr[0];
                                    }
                                    break;
                            }
                            break;
                        case State.GET_VALUE:
                            switch(chr[0])
                            {
                                case '\"' :
                            
                                    if (openDoubleQuote == false)
                                    {
                                        openDoubleQuote = true;
                                    }
                                    else
                                    {
                                        KeyValuePair<string, string> pair = new KeyValuePair<string, string>(name, value);
                                        results.Add(pair);
                                        name = "";
                                        value = "";
                                        state = State.GET_NAME;
                                        openDoubleQuote = false;
                                    }
                                    break;
                                default :
                                if (openDoubleQuote == true)
                                {
                                    value += chr[0];
                                }
                                break;
                            }
                            break;
                    }
                    if (exit) break;
                }
                return results;
            }
        }
    }
