    class Customer {
        private static int lastID = 0;
        public int ID { get; private set;}
        Customer() {
            this.ID = lastID++;
        }
