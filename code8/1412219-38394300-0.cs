    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication3
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                Block block = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if (inputLine.StartsWith("ONE"))
                        {
                            block = new Block();
                            Block.blocks.Add(block);
                        }
                        block.lines.Add(inputLine);
                    }
                }
            }
         }
        public class Block
        {
            public static List<Block> blocks = new List<Block>(); 
            public List<string> lines { get; set; }
            public Block()
            {
                lines = new List<string>();
            }
        }
    }
