    string connectionString = "User='myusername';Password='mypassword';Server='http://couchbase40'";
    using (CouchbaseConnection connection = new CouchbaseConnection(connectionString)) {
      CouchbaseCommand cmd = new CouchbaseCommand("SELECT * FROM Customer", connection);
      CouchbaseDataReader rdr = cmd.ExecuteReader();
 
      while (rdr.Read()) {
        Console.WriteLine(String.Format("\t{0} --> \t\t{1}", rdr["Name"],     rdr["TotalDue"]));
      }
    }
