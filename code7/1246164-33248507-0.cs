    class BulkBook : Book
        ...
        public void BulkOrder()
        {
            Copies = Copies + BATCH_SIZE;
        }
