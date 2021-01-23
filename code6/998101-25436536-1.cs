    public void ProcessDataItemTest()
    {
        string value = "{\"date\":\"2014-07-21T21:47:13.032415435Z\"}";
        try
        {
            var x = JsonConvert.DeserializeObject<DateTest>(value);
            var d = x.date;
            Console.WriteLine(d.ToString()); //output: 7/21/2014 9:47:13 PM
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    internal class DateTest
    {
        public DateTime date { get; set; }
    }
