    public class Funds
    {
        public int usd { get; set; }
        public int btc { get; set; }
        public int ltc { get; set; }
    }
    public class Rights
    {
        public int info { get; set; }
        public int trade { get; set; }
        public int withdraw { get; set; }
    }
    public class Return
    {
        public Funds funds { get; set; }
        public Rights rights { get; set; }
        public int transaction_count { get; set; }
        public int open_orders { get; set; }
        public int server_time { get; set; }
    }
    public class RootObject
    {
        public int success { get; set; }
        public Return @return { get; set; }
    }
