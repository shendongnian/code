        public void LogListing(int initializer, int finalizer)
        {
            if (initializer != finalizer)
            {
                if (finalizer == initializer + 1)
                {
                    data_result.Add(initializer + "A");
                    data_result.Add(finalizer + "A");
                }
                else
                    data_result.Add(initializer + "A - " + finalizer + "A");
            }
            else
                data_result.Add(initializer + "A");
        }
