    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static List<Player> players = new List<Player>();
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                int lineCount = 0;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    lineCount++;
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if (lineCount > 1)
                        {
                            string[] playerStuff = inputLine.Split(';');
                            players.Add(new Player(playerStuff));
                        }
                        
                    }
                }
                reader.Close();
            }
     
        }
        public class Player
        {
            public string name { get; set;}
            public string team { get; set;}
            public string position { get; set;}
            public int hr { get; set;}
            public int rbi { get; set;}
            public double avg { get; set;}
            public Player(string[] line)
            {
                this.name = line[0];
                this.team = line[1];
                this.position = line[2];
                this.hr = int.Parse(line[3]);
                this.rbi = int.Parse(line[4]);
                this.avg = double.Parse(line[5]);
            }
        }
    }
