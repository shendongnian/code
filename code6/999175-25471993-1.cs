    public void Add(Person person)
    {
       if (!_list.Any(p => p.Prename == person.PreName && p.Lastname == person.Lastname))
       {
          _list.Add(person);
       }
    }
