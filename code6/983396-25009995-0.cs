    public static IEnumerable<Person> Filter(this IEnumerable<Person> source, 
        string firstname, string lastname)
    {
        if (firstname != null)
        {
            source = from person in source
                     where person.Firstname.Contains(firstname)
                     select person;
        }
        if (lastname != null)
        {
            source = from person in source
                     where person.Lastname.Contains(lastname)
                     select person;
        }
        return source;
    }
