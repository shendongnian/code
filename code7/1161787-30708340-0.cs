    public void GetJson()
    {
        using (StreamReader r = new StreamReader("filename.json"))
        {
            string data = r.ReadToEnd();
            List<Step> steps = JsonConvert.DeserializeObject<List<Step>>(data);
        }
    }
    public class Step
    {
        public int divisor { get; set; }
        public int dividend { get; set; }
        public int product { get; set; }
        public int quotient { get; set; }
        public int remainder { get; set; }
    }
