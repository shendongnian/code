    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    
    namespace StackOverflow
    {
        #region Models
        public class Person
        {
            public int userID { set; get; }
            public string userName { get; set; }
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string email { get; set; }
            public List<int> someAttr { get; set; }
            public List<int> otherAttr { get; set; }
    
            public List<SomeModel> modelAttr { get; set; }
            public List<AnotherModel> modelAttr2 { get; set; }
        }
        public class SomeModel
        {
            public int SomeProperty { get; set; }
        }
        public class AnotherModel
        {
            public string AnotherProperty { get; set; }
        }
        #endregion
    
        public class PersonRepository
        {
            // Before you can use this repository you need to setup a Person table to store your objects
            // CREATE TABLE Person (UserID int primary key, PersonObject text)
    
            private string _dbConnectionString;
            public PersonRepository(string dbConnectionString)
            {
                this._dbConnectionString = dbConnectionString;
            }
    
            public void WriteToDatabase(Person p)
            {
                using (var conn = new SqlConnection(_dbConnectionString))
                {
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        // Serialize the person object to JSON to store in the database
                        var personJson = JsonConvert.SerializeObject(p);
    
                        command.CommandText = "INSERT INTO Person (UserID, PersonObject) values (@UserId, @PersonObject)";
                        command.Parameters.Add(new SqlParameter("@UserID", p.userID));
                        command.Parameters.Add(new SqlParameter("@PersonObject", personJson));
    
                        // Execute the SQL command to insert the record
                        command.ExecuteNonQuery();
                    }
                }
            }
    
            public Person ReadFromDatabase(int userId)
            {
                using (var conn = new SqlConnection(_dbConnectionString))
                {
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT PersonObject from Person where UserID = @UserID";
                        command.Parameters.AddWithValue("@UserID", userId);
    
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Read out the JSON respresentation of the Person object
                                var personJson = reader.GetString(0);
    
                                // Deserialize it back into a Person object. Note you will have to deal with versioning issues.
                                return JsonConvert.DeserializeObject<Person>(personJson);
                            }
                            else
                                throw new ApplicationException($"No person found with user ID {userId}");
                        }
                    }
                }
            }
        }
    }
