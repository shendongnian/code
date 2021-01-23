    class Demo
    {
        public int Distance { get; set; }
        public int Frequency { get; set; }
        public override string ToString()
        {
            return string.Format("Distance:{0}  Frequency:{1}", this.Distance, this.Frequency);
        }
    }
    List<Demo> list = new List<Demo>
        {
            new Demo{ Distance=3, Frequency=15},
            new Demo{ Distance=4, Frequency=17},
            new Demo{ Distance=5, Frequency=3},
        };
        int[] weight = { 30, 70 };
        var tmp = list.OrderByDescending(x => x.Distance * 0.3 + x.Frequency * 0.7);//there just a guess
        foreach(var q in tmp)
        {
            Console.WriteLine(q);
        }
