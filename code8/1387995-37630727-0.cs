    public Company(string[] names, Weapon[] weapons)
    {
        int length = names.Length;
        _members = new List<Character>();
        for (int i = 0; i < length; i++)
        {
            _members.Add(new Character(names[i], weapons[i]));
            Console.WriteLine("added {0} to character list", _members[i].Name);
        }
        Console.WriteLine("characters {0} and {1} exist after the for", _members[0].Name, _members[1].Name);
        _size = length;
    }
