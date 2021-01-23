    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication63
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                List<AlphaNumberic> aN = new List<AlphaNumberic>() { "a", "1", "b", "2" };
                aN.Sort((x, y) => x.CompareTo(y));
            }
        }
        public class AlphaNumberic
        {
            int results = 0;
            public string alphaNumeric { get; set; }
            public AlphaNumberic(string value)
            {
                this.alphaNumeric = value;
            }
            public static implicit operator string(AlphaNumberic d)
            {
                return d.alphaNumeric;
            }
            public static implicit operator AlphaNumberic(string d)
            {
                return new AlphaNumberic(d);
            }
            public int CompareTo(AlphaNumberic compareItem)
            {
                int thisNum;
                int num;
                if (int.TryParse(compareItem.alphaNumeric, out num))
                {
                    if (int.TryParse(this.alphaNumeric, out thisNum))
                    {
                        //alphaNumeric and compareItem both integers;
                        results = thisNum.CompareTo(num);
                    }
                    else
                    {
                        //alphaNumeric not an integer and compareItem integers;
                        results = 1;
                    }
                }
                else
                {
                    if (int.TryParse(this.alphaNumeric, out thisNum))
                    {
                        //alphaNumeric is an integer and compareItem not an integers;
                        results = -1;
                    }
                    else
                    {
                        //alphaNumeric not an integer and compareItem not an integers;
                        results = alphaNumeric.CompareTo(compareItem);
                    }
                }
                return results;
            }
        }
    }
