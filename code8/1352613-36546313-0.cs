    class Customer {
        private static int lastID = 0;
        public int ID { get; set;}
        Customer() {
            this.ID = lastID++;
        }
