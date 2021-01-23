        public class Person
        {
            public string Name { get; set; }
            public int Year { get; set; }
            public string Gender { get; set; }
            public int RelativeAge
            {
                get { return  DateTime.Today.Year - Year; }
            }
            public Person(string name, int year, string gender)
            {
                Name = name;
                Year = year;
                Gender = gender;
            }
            public string AgeStatement()
            {
                return string.Format("{0} is {1} {2} old.", Name, RelativeAge, MakePlural("year", RelativeAge));
            }
            /// <summary>
            /// Add an S to values over one.
            /// </summary>
            /// <param name="element">Item to be plural</param>
            /// <param name="value"></param>
            /// <returns></returns>
            public string MakePlural(string element, int value)
            {
                return element + ((value > 1) ? "s" : "");
            }
        }
