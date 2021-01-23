    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static List<Day> days = new List<Day>();
            static void Main(string[] args)
            {
            }
        }
        public class Day
        {
            int day { get; set; }
            int housesBought { get; set; }
            int money { get; set; }
            List<Day> nextDay = new List<Day>();
        }
    }
