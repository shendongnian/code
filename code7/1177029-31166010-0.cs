    using System;
    using System.Data.SqlClient;
    
    namespace TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                Staff s = new Staff();
    
                s.FirstName = "abc";
                s.Surname = "xyz";
                s.Email = "a@a.com";
                s.Phone = "1234";
                s.Notes = "testnotes";
                
                bool isInserted = AddStaff(s);            
            }
    
            public static bool AddStaff(Staff s)
            {
                SqlConnection _db = new SqlConnection("Initial Catalog=XXXXXX;Data Source=localhost;Integrated Security=SSPI;");
    
                String query = @"INSERT into Staff (firstname, surname, email, phone, notes, status)";
                query += @" VALUES (@_firstname, @_surname, @_email, @_phone, @_notes, @_status)";
    
    
                SqlCommand myCommand = new SqlCommand(query, _db);
    
                myCommand.Parameters.AddWithValue("@_firstname", s.FirstName);
                myCommand.Parameters.AddWithValue("@_surname", s.Surname);
                myCommand.Parameters.AddWithValue("@_email", s.Email);
                myCommand.Parameters.AddWithValue("@_phone", s.Phone);
                myCommand.Parameters.AddWithValue("@_notes", s.Notes);
                myCommand.Parameters.AddWithValue("@_status", s.StatusToString());
    
                int res = 0;
    
                _db.Open();
                res = myCommand.ExecuteNonQuery();   // Run the statement.
                _db.Close();
    
                if (res == 1) return true;           // Should only update one row.
                else return false;
            }
            
        }
    
        class Staff
        {
            private string _firstname;
            private string _surname;
            private string _email;
            private string _phone;
            private string _notes;
            private string _status;
    
            public string FirstName
            {
                get
                {
                    return _firstname;
                }
                set
                {
                    _firstname = value;
                }
            }
    
            public string Surname
            {
                get
                {
                    return _surname;
                }
                set
                {
                    _surname = value;
                }
            }
    
            public string Email
            {
                get
                {
                    return _email;
                }
                set
                {
                    _email = value;
                }
            }
    
            public string Phone
            {
                get
                {
                    return _phone;
                }
                set
                {
                    _phone = value;
                }
            }
    
            public string Notes
            {
                get
                {
                    return _notes;
                }
                set
                {
                    _notes = value;
                }
            }
    
            public string StatusToString()
            {
                return "Valid";
            }
    
        }
    }
