    using System;
    using Newtonsoft.Json;
    class Sometype
    {
        public Number pos { get; set; }
    }
    class Number
    {
        private uint num;
        private Number(uint num)
        {
            this.num = num;
        }
        public static implicit operator uint(Number sid)
        {
            return sid.num;
        }
        public static implicit operator Number(Int64 id)
        {
            return new Number((uint)id);
        }
    }
    class Program
    {
        static void Main()
        {
            Sometype thing = JsonConvert.DeserializeObject<Sometype>("{\"pos\":123}");
        }
    }
