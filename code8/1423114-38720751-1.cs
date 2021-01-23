    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication6
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Script.ReadScripts(FILENAME);   
            }
        }
        public class Script
        {
            enum State
            {
                Get_Script,
                Read_Script
            }
            public static List<Script> scripts = new List<Script>();
            public int version { get; set; }
            public string script { get; set; }
            public static void ReadScripts(string filename)
            {
                string inputLine = "";
                string pattern = "DBVer=(?'version'\\d+)";
                State state = State.Get_Script;
                StreamReader reader = new StreamReader(filename);
                Script newScript = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        switch (state)
                        {
                            case State.Get_Script :
                                if(inputLine.StartsWith("-----"))
                                {
                                    newScript = new Script();
                                    scripts.Add(newScript);
                                    string version = 
                                      Regex.Match(inputLine, pattern).Groups["version"].Value;
                                    newScript.version = int.Parse(version);
                                    newScript.script = "";
                                    state = State.Read_Script;
                                }
                                break;
                            case State.Read_Script :
                                if (inputLine.StartsWith("-----"))
                                {
                                    state = State.Get_Script;
                                }
                                else
                                {
                                    if (newScript.script.Length == 0)
                                    {
                                        newScript.script = inputLine;
                                    }
                                    else
                                    {
                                        newScript.script += "\n" + inputLine;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
