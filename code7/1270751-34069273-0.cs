    class ValuesObj{
        public string Values {get;set;}
    }
    // whatever code here
    private Func<Position, ValuesObj, Position> GetPerson = new Func<Person, ValuesObj, Person>
    ((person, valuesObj) => {
                    string values = valuesObj.Values;
                    person.Values = Jil.JSON.Deserialize<Dictionary<string, string>>((string)values);
                    return position;
                });
    
    string sql =   "SELECT text
                    FROM otherTable
    
                    SELECT Name, Id, Age, Values 
                    FROM People 
                    WHERE Id = @Id"
    
    SqlMapper.GridReader gridReader = connToDeviceConfig.QueryMultiple(sql, new {Id = 5}, commandType: CommandType.StoredProcedure);
    
    List<string> listOfOtherStuff = gridReader.Read<string>().ToList();
    List<Person> people = gridReader.Read<Person, ValuesObj, Person>(GetPerson, splitOn: "Values").ToList();
