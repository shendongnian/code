    static void ForWithVariable(IEnumerable<Person> clients)
    {
        var adults = clients.Where(x => x.Age > 20);
        foreach (var client in adults)
        {
            Console.WriteLine(client.Age.ToString());
        }
    }
    static void ForWithoutVariable(IEnumerable<Person> clients)
    {
        foreach (var client in clients.Where(x => x.Age > 20))
        {
            Console.WriteLine(client.Age.ToString());
        }
    }
