    using (TransactionScope scope123 = new TransactionScope())
        {
            using (SqlConnection connection1 = new SqlConnection(connectString1))
            {
                // Do some work
                using (SqlConnection connection2 = new SqlConnection(connectString2))
                {
                    // Do some more work
                }
            }
