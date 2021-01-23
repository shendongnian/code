    public struct TaxPayer
    {
        public string SSN { get; set; }
        public decimal Gross { get; set; }
        public decimal Tax { get; set; }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list=new List<TaxPayer>() { 
                new Person() { SSN="172-00-1234", Gross=30000m, Tax=8400m },
                new Person() { SSN="137-00-7263", Gross=38000m, Tax=8800m }, 
                new Person() { SSN="138-00-8271", Gross=27000m, Tax=7300m }, 
            };
            //each number after the comma is the column space to leave
            //negative means left aligned, and positive is right aligned
            string format="{0,-12} {1,-13} {2,-13}";
            string[] heading = new string[] { "SSN Number", "Gross Income", "Taxes" };
            
            Console.WriteLine(string.Format(format, heading));
            for (int i = 0; i < list.Count; i++)
			{
                string[] row=new string[] { list[i].SSN, list[i].Gross.ToString("C"), list[i].Tax.ToString("C") };
                Console.WriteLine(string.Format(format, row));
			}
        }
    }
