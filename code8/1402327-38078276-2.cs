    // create a separate class - call it whatever you like
    public class DataProvider
    {
        // define a method to provide that data to you
        public List<string> GetPeople()
        {
            // define connection string (I'd really load that from CONFIG, in real world)
            string connstring = "Server=MSEDTOP;Database=AdventureWorks2014;Trusted_Connection=Yes;";
            // define your query
            string query = "SELECT FirstName, LastName FROM Person.Person";
            // prepare a variable to hold the results
            List<string> entries = new List<string>();
                
            // put your SqlConnection and SqlCommand into "using" blocks
            using (SqlConnection conn = new SqlConnection(connstring))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                // iterate over the results using a SqlDataReader
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        // get first and last name from current row of query
                        string firstName = rdr.GetFieldValue<string>(0);
                        string lastName = rdr.GetFieldValue<string>(1);
                        // add entry to result list
                        entries.Add(firstName + " " + lastName);
                    }
                    rdr.Close();
                }
                conn.Close();
            }
            // return the results
            return entries;
        }
    }
