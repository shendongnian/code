    public Person GetPersonDetail(int PersonId)
    {
        try
        {
            var oPara = new DynamicParameters();
            oPara.Add("@PersonId", PersonId, dbType: DbType.Int);
            
            var person = new Person();
            using (var multiResults = _connection.QueryMultiple(GetPersonDetail, oPara, commandType: CommandType.StoredProcedure))
            {
                person.Person = multiResults.Read<Person>().FirstOrDefault();
                person.Addresses = multiResults.Read<Address>();
    			person.BankAccount = multiResults.Read<BankAccount>().FirstOrDefault();
            }
            return person;
        }
        catch (Exception ex)
        {
            thow;
        }
    }
