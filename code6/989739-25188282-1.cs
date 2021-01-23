    while (dataReader.Read())
    {
        var person = new Person();
        var id = 0;
        var idValue = dataReader.GetValue(0);
        if (int.TryParse(idValue, out id))
            person.ID = id;
        else
        {
            // ID was invalid, handle the error here
        }
        person.Name = dataReader.GetValue(1).ToString();
        people.Add(person);
    }
