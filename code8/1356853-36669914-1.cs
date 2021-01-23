    class Data
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string WeatherReport1 { get; set; }
        public string WeatherReport2 { get; set; }
        public string WeatherReport3 { get; set; }
        public string WeatherReport4 { get; set; }
        public string WeatherReport5 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Data objdata;
            Data[] array = new Data[5];
            for (int i = 0; i < array.Length; i++)
            {
                objdata = new Data();
                objdata.Year = "Year";
                objdata.Month = "Month";
                objdata.WeatherReport1 = "report1";
                objdata.WeatherReport2 = "report2";
                objdata.WeatherReport3 = "report3";
                objdata.WeatherReport4 = "report4";
                objdata.WeatherReport5 = "report5";
                
                array[i] = objdata;
            }
            for(int i=0;i<array.Length;i++)
            {
                Console.WriteLine(array[i].Year+" "+array[i].Month+" "+array[i].WeatherReport1+" "+array[i].WeatherReport2+" "+array[i].WeatherReport3+" "+array[i].WeatherReport4+" "+array[i].WeatherReport5);
            }
            Console.Read();
        }
