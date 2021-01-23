    class Customer {
        private static int lastID = 0;
        public string name { get; set; }
        public int[] accounts { get; set; }
        public int ID { get; private set; }
        public int balance { get { return 100; } }
        public double interest { get { return this.balance * 1.05; } }
        Customer(string name, int[] accounts) {
            this.ID = lastID++;
            this.accounts = accounts;
            this.balance = 100;
            this.name = name;
        }
