    class Program {
        static void Main(string[] args) {
            List<Criteria> list = new List<Criteria>() {
                new Criteria(Color.green, Country.england, Town.london, GoodBad.good, DayOfTheWeek.sunday, Daytime.evening),
                new Criteria(Color.red, Country.thenetherlands, Town.amsterdam, GoodBad.bad, DayOfTheWeek.monday, Daytime.night),
                new Criteria(Color.blue, Country.america, Town.newyork, GoodBad.bad, DayOfTheWeek.tuesday, Daytime.morning),
            };
            
            Console.WriteLine("- Native sorting:");
            list.Sort();
            foreach(var criteria in list) {
                Console.WriteLine(criteria);
            }
            Console.WriteLine();
            Console.WriteLine("- By Color:");
            IOrderedEnumerable<Criteria> byColor = list.OrderBy(c => c.Color);
            foreach(var criteria in byColor) {
                Console.WriteLine(criteria);
            }
            Console.WriteLine();
            Console.WriteLine("- By Country:");
            IOrderedEnumerable<Criteria> byCountry = list.OrderBy(c => c.Country);
            foreach(var criteria in byCountry) {
                Console.WriteLine(criteria);
            }
            Console.WriteLine();
            Console.WriteLine("- By Town:");
            IOrderedEnumerable<Criteria> byTown = list.OrderBy(c => c.Town);
            foreach(var criteria in byTown) {
                Console.WriteLine(criteria);
            }
            Console.WriteLine();
            Console.WriteLine("- By Good:");
            IOrderedEnumerable<Criteria> byGood = list.OrderBy(c => c.GoodBad);
            foreach(var criteria in byGood) {
                Console.WriteLine(criteria);
            }
            Console.WriteLine();
            Console.WriteLine("- By DayOfTheWeek:");
            IOrderedEnumerable<Criteria> byDayOfTheWeek = list.OrderBy(c => c.DayOfTheWeek);
            foreach(var criteria in byDayOfTheWeek) {
                Console.WriteLine(criteria);
            }
            Console.WriteLine();
            Console.WriteLine("- By Daytime:");
            IOrderedEnumerable<Criteria> byDaytime = list.OrderBy(c => c.Daytime);
            foreach(var criteria in byDaytime) {
                Console.WriteLine(criteria);
            }
            Console.ReadKey();
        }
    }
    sealed class Criteria : IComparable<Criteria> {
        public readonly Color Color;
        public readonly Country Country;
        public readonly Town Town;
        public readonly GoodBad GoodBad;
        public readonly DayOfTheWeek DayOfTheWeek;
        public readonly Daytime Daytime;
        public Criteria(Color color, Country country, Town town, GoodBad goodBad, DayOfTheWeek dayOfTheWeek, Daytime daytime) {
            this.Color = color;
            this.Country = country;
            this.Town = town;
            this.GoodBad = goodBad;
            this.DayOfTheWeek = dayOfTheWeek;
            this.Daytime = daytime;
        }
        public override int GetHashCode() {
            int result = (int)Color | (int)Country << 2 | (int)Town << 5 | (int)GoodBad << 8 | (int)DayOfTheWeek << 9 | (int)Daytime << 12;
            return result;
        }
        public override string ToString() {
            return string.Join(" ", Color, Country, Town, GoodBad, DayOfTheWeek, Daytime);
        }
        public int CompareTo(Criteria that) {
            int result = this.Color.CompareTo(that.Color);
            if(result != 0) {
                return result;
            }
            result = this.Country.CompareTo(that.Country);
            if(result != 0) {
                return result;
            }
            result = this.Town.CompareTo(that.Town);
            if(result != 0) {
                return result;
            }
            result = this.GoodBad.CompareTo(that.GoodBad);
            if(result != 0) {
                return result;
            }
            result = this.DayOfTheWeek.CompareTo(that.DayOfTheWeek);
            if(result != 0) {
                return result;
            }
            result = this.Daytime.CompareTo(that.Daytime);
            return result;
        }
    }
    //2 bits
    enum Color {
        green,
        red,
        blue,
    }
    //3 bits
    enum Country {
        england,
        thenetherlands,
        america,
    }
    //3 bits
    enum Town {
        london,
        amsterdam,
        newyork,
    }
    //1 bit
    enum GoodBad {
        good,
        bad,
    }
    //3 bits
    enum DayOfTheWeek {
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday,
    }
    //3 bits
    enum Daytime {
        morning,
        afternoon,
        evening,
        night,
    }
