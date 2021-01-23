        public void Test()
        {
            try
            {
                // Fixture setup
                // Create and insert data into Database (with plain ADO code)
                // Exercise system
                // Verify outcome
                // use your data layer here
            }
            finally
            {
                // Teardown - other methods to clean the tables afterwards
                DatabaseHelper.ClearLookups();
                DatabaseHelper.ClearBeds();
                ...
            }
        }
