    List<PersonWithAddress> PersonWithAddressList = new List<PersonWithAddress>();
    using (var connection = new SQLitePCL.SQLiteConnection(DB_PATH))
    {
        using (var statement = connection.Prepare(@"SELECT Person.Id, Person.Name, Person.Surname, Address.Street, Address.City, Address.Country FROM Person INNER JOIN Address ON Person.AddressId = Address.Id;"))
        {
            while (statement.Step() == SQLitePCL.SQLiteResult.ROW)
            {
                var personWithAddress = new PersonWithAddress();
                personWithAddress.Id = Convert.ToInt32(statement[0]);
                personWithAddress.Name = (string)statement[1];
                personWithAddress.Surname = (string)statement[2];
                personWithAddress.mAddress.Street = (string)statement[3];
                personWithAddress.mAddress.City = (string)statement[4];
                personWithAddress.mAddress.Country = (string)statement[5];
                
                PersonWithAddressList.Add(personWithAddress);
            }
        }
    }
