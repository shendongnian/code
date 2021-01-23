    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                  List<string> data = new List<string>{
                    "3.5.0.1", "3.4.1.9", "3.4.1.56", "3.4.1.55", "3.4.1.46",
                    "3.4.1.45", "3.4.1.44", "3.4.1.30", "3.4.1.3", "3.4.1.22",
                    "3.4.1.2", "3.4.1.11", "3.4.1.0", "3.4.0.7", "3.4.0.3",
                    "3.4.0.1", "3.3.0.8", "3.3.0.4", "3.3.0.0", "3.2.0.9",
                    "3.2.0.6", "3.2.0.3", "3.2.0.27", "3.2.0.20", "3.2.0.15",
                    "3.2.0.1", "3.2.0.0", "3.1.0.7", "3.1.0.15", "3.1.0.14"
                  };
                  List<SortPara> sortPara = data.Select(x => new SortPara(x)).ToList();
                  data = sortPara.OrderBy(x => x).Select(x => x.strNumbers).ToList();
                  data = sortPara.OrderByDescending(x => x).Select(x => x.strNumbers).ToList();
            }
        }
        public class SortPara : IComparable<SortPara>
        {
            public List<int> numbers { get; set; }
            public string strNumbers { get; set; }
            public SortPara(string strNumbers)
            {
                this.strNumbers = strNumbers;
                numbers = strNumbers.Split(new char[] { '.' }).Select(x => int.Parse(x)).ToList();
            }
            public int CompareTo(SortPara other)
            {
                int shortest = this.numbers.Count < other.numbers.Count ? this.numbers.Count : other.numbers.Count;
                int results = 0;
                for (int i = 0; i < shortest; i++)
                {
                    if (this.numbers[i] != other.numbers[i])
                    {
                        results = this.numbers[i].CompareTo(other.numbers[i]);
                        break;
                    }
                }
                return results;
            }
        }
    }
