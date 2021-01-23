    public class ABC
    {
        public int w1 { get; set; }
        public int w2 { get; set; }
        public int w3 { get; set; }
        public ABC()
        {
            w1 = 7;
            w2 = 8;
            w3 = 9;
        }
        public void DoSomething()
        {
            var i = 1;
            var name = "w" + (i + 1).ToString(); // w2
            var value = (int)this.GetType().GetProperty(name).GetValue(this);
            DoSomething(value);
        }
        public void DoSomething(int curr)
        {
            Console.WriteLine(curr); // 8
        }
    }
