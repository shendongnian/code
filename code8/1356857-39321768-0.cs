    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SOSorting
    {
        internal class Program
        {
            public static string[] years = { "1990", "1990", "1990", "1991", "1991", "1991", "1991", "1992", "1992" };// File.ReadAllLines(@"../../bin/Debug/WS1/Year.txt");
    
            public static string[] months = { "January", "February", "March", "January", "February", "March", "April", "January", "February" };// File.ReadAllLines(@"../../bin/Debug/WS1/Month.txt");
    
            public static string[] afs = { "5", "6", "7", "4", "2", "3", "7", "8", "1" }; //File.ReadAllLines(@"../../bin/Debug/WS1/WS1_AF.txt");
    
            public static string[] rains = { "50", "30", "40", "40", "25", "60", "30", "21", "21" };// File.ReadAllLines(@"../../bin/Debug/WS1/WS1_Rain.txt");
    
            public static string[] suns = { "85", "80", "81", "82", "80", "89", "90", "92", "75" };//File.ReadAllLines(@"../../bin/Debug/WS1/WS1_Sun.txt");
    
            public static string[] tmaxs = { "70", "60", "65", "65", "24", "24", "20", "75", "70" };//File.ReadAllLines(@"../../bin/Debug/WS1/WS1_TMax.txt");
    
            public static string[] tmins = { "10", "9", "8", "9", "10", "12", "12", "13", "21" }; //File.ReadAllLines(@"../../bin/Debug/WS1/WS1_TMin.txt");
    
            private static void Main(string[] args)
            {
                //changes console text to green
                Console.ForegroundColor = ConsoleColor.Green;
                //runs Forge_Array
                Forge_Array();
    
                Console.ReadKey();
            }
    
            public static void Forge_Array()
            {
                //sets the number of rows in the 2D array to the length of the years array
                int arrayRows = years.Length;
    
                //sets the number of columns to 7
                int arrayColumns = 7;
    
                //creates new 2D string array. the size uses the values prior to this
                string[,] weather1 = new string[arrayRows, arrayColumns];
    
                //create list of weather objects
                List<Weather> weatherList = new List<Weather>();
    
                for (int i = 0; i < arrayRows; i++)
                {
                    weatherList.Add(new Weather(years[i], months[i], afs[i], rains[i], suns[i], tmaxs[i], tmins[i]));
                }
    
                //creates strings for the titles of all of the columns in the array
                string ytxt = "Year";
                string mtxt = "Month";
                string atxt = "Air Frost";
                string rtxt = "Rain";
                string stxt = "Sun";
                string matxt = "Max Temp";
                string mitxt = "Min Temp";
    
                //gets the lenght of the 2D array
                int rowLength = weather1.GetLength(0);
    
                //writes out the titles for the columns for the array
                Console.WriteLine("===============================================================================");
                Console.WriteLine("| {0 , -4} || {1, -10} || {2, -9} || {3, -6} || {4, -6} || {5, -6} || {6, -6} |", ytxt, mtxt, atxt, rtxt, stxt, matxt, mitxt);
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Filtered to specific year");
                foreach (var weather in weatherList.Where(x => x.Date.Year == 1991)) // of course you can parametrize it
                {
                    Console.WriteLine(weather);
                }
    
                Console.WriteLine("===============================================================================");
    
                Console.WriteLine("===============================================================================");
                Console.WriteLine("| {0 , -4} || {1, -10} || {2, -9} || {3, -6} || {4, -6} || {5, -6} || {6, -6} |", ytxt, mtxt, atxt, rtxt, stxt, matxt, mitxt);
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Not filtered");
                foreach (var weather in weatherList)
                {
                    Console.WriteLine(weather);
                }
    
                Console.WriteLine("===============================================================================");
    
                Console.WriteLine("===============================================================================");
    
                Console.WriteLine("===============================================================================");
                Console.WriteLine("| {0 , -4} || {1, -10} || {2, -9} || {3, -6} || {4, -6} || {5, -6} || {6, -6} |", ytxt, mtxt, atxt, rtxt, stxt, matxt, mitxt);
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Filtered by suns and year");
                foreach (var weather in weatherList.Where(x => x.Suns > 89 && x.Date.Year == 1991))
                {
                    Console.WriteLine(weather);
                }
    
                Console.WriteLine("===============================================================================");
                Console.ReadKey();
            }
        }
    
        public class Weather
        {
            private DateTime _date;
            private readonly string _year;
            private readonly string _month;
            private int _afs;
            private int _rains;
            private int _suns;
            private int _tmaxs;
            private int _tmins;
    
            public Weather(string year, string month, string afs, string rains, string suns, string tmaxs, string tmins)
            {
                if (tmins == null)
                    throw new ArgumentNullException("tmins");
                if (tmaxs == null)
                    throw new ArgumentNullException("tmaxs");
                if (suns == null)
                    throw new ArgumentNullException("suns");
                if (rains == null)
                    throw new ArgumentNullException("rains");
                if (afs == null)
                    throw new ArgumentNullException("afs");
                if (month == null)
                    throw new ArgumentNullException("month");
                if (year == null)
                    throw new ArgumentNullException("year");
    
                //Have to use dictionary for quick translation
                int monthNumber = _months[month];
    
                //Date time will indicate first day of month but we care only about month and year anyway
                _date = new DateTime(int.Parse(year), monthNumber, 1);
                _year = year;
                _month = month;
                _afs = int.Parse(afs);
                _rains = int.Parse(rains);
                _suns = int.Parse(suns);
                _tmaxs = int.Parse(tmaxs);
                _tmins = int.Parse(tmins);
            }
    
            public DateTime Date { get { return _date; } }
            public int Afs { get { return _afs; } }
            public int Rains { get { return _rains; } }
            public int Suns { get { return _suns; } }
            public int Tmaxs { get { return _tmaxs; } }
            public int Tmins { get { return _tmins; } }
    
            private Dictionary<string, int> _months = new Dictionary<string, int>()
                    {
                                    { "January", 1},
                                    { "February", 2},
                                    { "March", 3},
                                    { "April", 4},
                                    { "May", 5},
                                    { "June", 6},
                                    { "July", 7},
                                    { "August",8},
                                    { "September", 9},
                                    { "October", 10},
                                    { "November", 11},
                                    { "December", 12}
                    };
    
            public override string ToString()
            {
                return String.Format("| {0, -4} || {1, -10} || {2, -9} || {3, -6} || {4, -6} || {5, -8} || {6, -8} |", _year, _month, _afs, _rains, _suns, _tmaxs, _tmins);
            }
        }
    }
