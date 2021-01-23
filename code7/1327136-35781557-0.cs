    /*Parse class*/
    public class ParseFileRead
    {
        public int open { get; set; }
        public int buy { get; set; }
        public int sell { get; set; }
        public double settleMM { get; set; }
        public string account { get; set; }
        public string underlying { get; set; }
        public string symbol { get; set; }
        public ParseFileRead(string[] arr)
        {
            this.account = arr[0];
            this.underlying = arr[12];
            this.symbol = arr[1];
            this.open = Convert.ToInt32(arr[6]);
            this.buy = Convert.ToInt32(arr[7]);
            this.sell = Convert.ToInt32(arr[8]);
            this.settleMM = Convert.ToDouble(arr[10]);
        }
    }
    
    /*Parsing code*/
     while (!r.EndOfStream)
        {
            string line = r.ReadLine();
            //Send this to Parse class
            string [] values = line.Split(',');
            //parse records
            Console.WriteLine(values[6]); //This is printing the accurate value for parse.open
            ParseFileRead parse = new ParseFileRead(values);
            Console.WriteLine(parse.open); //This is not printing the accurate value
        }
