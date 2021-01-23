    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        enum State
        {
            FIND_RECORD,
            GET_LOCATION,
            GET_DATES
        }
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                State state = State.FIND_RECORD;
                LocationDefinition location = null;
                string inputLine = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length == 0)
                    {
                        state = State.FIND_RECORD;
                    }
                    else
                    {
                        switch (state)
                        {
                            case State.FIND_RECORD :
                                if (inputLine.StartsWith("PlaceName"))
                                {
                                    state = State.GET_LOCATION;
                                }
                                else
                                {
                                    if (inputLine.StartsWith("Date"))
                                    {
                                        state = State.GET_DATES;
                                    }
                                }
                                break;
                            case State.GET_DATES :
                                if (location.dates == null) location.dates = new CountDefinition();
                                location.dates.dates.Add(new CountDefinition(inputLine));
                                break;
                            case State.GET_LOCATION :
                                location = new LocationDefinition(inputLine);
                                break;
                        }
                    }
                }
            }
        }
        public class LocationDefinition
        {
            public static List<LocationDefinition> locations = new List<LocationDefinition>();
            public CountDefinition dates { get; set; }
            public string PlaceName { get; set; }
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public double Elevation { get; set; }
            public LocationDefinition(string location)
            {
                string[] array = location.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                PlaceName = array[0];
                Longitude = double.Parse(array[1]);
                Latitude = double.Parse(array[2]);
                Elevation = double.Parse(array[3]);
                locations.Add(this);
             }
        }
     
        public class CountDefinition
        {
            public List<CountDefinition> dates = new List<CountDefinition>();
            public DateTime Date { get; set; }
            public int Count { get; set; }
            public CountDefinition() { ;}
     
            public CountDefinition(string count)
            {
                string[] array = count.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Date = DateTime.Parse(array[0]);
                Count = int.Parse(array[1]);
                dates.Add(this);
            }
        }
    }
