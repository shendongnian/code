    public List<Person> getAdults()
    {
        List<Person> Adults = new List<Person>();
        foreach (Person test in allPersons)
        {
            if (test.Age > 20)
            {
                Adults.Add(test);
                //Console.WriteLine(test.ToString() + "\n");
            }
        }
        return Adults;
    }
