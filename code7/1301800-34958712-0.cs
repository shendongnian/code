        public class MyProgram
        {
    
            public List<Person> ReadRecords()
            {
                // Set up your connection
                SqlConnection conn = new SqlConnection();
                conn.Open();
    
                SqlCommand cmd = new SqlCommand("SELECT * FROM Person", conn);
                SqlDataReader reader = cmd.ExecuteReader();
    
                List<Person> personRecords = new List<Person>();
    
                while (reader.Read())
                {
                    Person p = new Person(reader, conn);
                    personRecords.Add(p);
                }
    
                return personRecords;
            }
    
            public int UpdateRecords(IEnumerable<Person> records, SqlConnection conn)
            {
                int personsUpdated = 0;
                int recordsUpdated = 0;
    
                foreach (Person p in records)
                {
                    if (p.Changed)
                    {
                        recordsUpdated += p.Update(conn);
                        personsUpdated++;
                    }
                }
    
                return recordsUpdated;
            }
        }
    
        public class Person
        {
            public const string SqlGetPersonEmailsCommand = "SELECT Email_Id, Email FROM Emails WHERE Person_Id = @Person_Id";
            public const string SqlUpdatePersonCommand = "UPDATE Person SET Name = @Name WHERE Id = @OriginalId";
            public const string SqlUpdatePersonEmailCommand = "UPDATE Emails SET Email = @Email WHERE Email_Id = @Email_Id";
    
            public int OriginalId { get; private set; }
    
            private bool personChanged;
            private bool emailsChanged { get { return changedEmails.Count > 0; } }
            public bool Changed { get { return personChanged || emailsChanged; } }
    
            private int _id;
            public int Id
            {
                get { return _id; }
                set
                {
                    throw new Exception("Changing Id is not allowed.");
                }
            }
    
            private string _name;
    
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    personChanged = true;
                }
            }
    
            private List<int> changedEmails;
            private Dictionary<int, string> _emailAddresses;
            public string[] EmailAddresses
            {
                get
                {
                    string[] values = new string[_emailAddresses.Count];
                    _emailAddresses.Values.CopyTo(values, 0);
                    return values;
                }
            }
    
            public void UpdateEmail(int emailId, string newEmail)
            {
                _emailAddresses[emailId] = newEmail;
                changedEmails.Add(emailId);
            }
    
            public Person(IDataReader reader, SqlConnection conn)
            {
                // Read ID (primary key from column 0)
                OriginalId = _id = reader.GetInt32(0);
    
                // Check if value in column 1 is Null; if so, set _name to Null, otherwise read the value
                _name = reader.IsDBNull(1) ? null : reader.GetString(1);
    
                // Now get all emails for this Person record
                SqlCommand readEmailsCmd = new SqlCommand(SqlGetPersonEmailsCommand, conn);
                readEmailsCmd.Parameters.Add("@Person_Id", SqlDbType.Int);
                readEmailsCmd.Parameters["@Person_Id"].Value = OriginalId;
    
                SqlDataReader emailReader = readEmailsCmd.ExecuteReader();
    
                changedEmails = new List<int>();
                _emailAddresses = new Dictionary<int, string>();
    
                if (emailReader.HasRows)
                {
                    while (emailReader.Read())
                    {
                        int emailId = emailReader.GetInt32(0);
                        string email = emailReader.GetString(1);
    
                        _emailAddresses.Add(emailId, email);
                    }
                }
            }
    
    
            public int Update(SqlConnection conn)
            {
                int rowsUpdated = 0;
    
                SqlCommand command = null;
    
                // Update Person record
                if (personChanged)
                {
                    command = new SqlCommand(SqlUpdatePersonCommand, conn);
    
                    command.Parameters.Add("@OriginalId", SqlDbType.Int);
                    command.Parameters["@OriginalId"].Value = OriginalId;
    
                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters["@Name"].Value = _name;
    
                    rowsUpdated = command.ExecuteNonQuery();
                }
    
                // Now update all related Email records
                foreach (int id in changedEmails)
                {
                    command = new SqlCommand(SqlUpdatePersonEmailCommand, conn);
    
                    command.Parameters.Add("@Email_Id", SqlDbType.Int);
                    command.Parameters["@Email_Id"].Value = id;
    
                    command.Parameters.Add("@Email", SqlDbType.NVarChar);
                    command.Parameters["@Email"].Value = _emailAddresses[id];
    
                    rowsUpdated = +command.ExecuteNonQuery();
                }
    
                return rowsUpdated;
            }
        }
