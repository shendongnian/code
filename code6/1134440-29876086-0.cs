    Stopwatch sw = new Stopwatch();
    sw.Start();
    List<PersonTwo> difference = personTwoList
    .GroupBy(x => new { FirstName = x.firstname.ToLower(), LastName = x.lastname.ToLower() })
    .Select(x => x.First())
    .Where(x => !personOneList.Any(y => y.name.Equals(x.firstname, StringComparison.InvariantCultureIgnoreCase) && y.surname.Equals(x.lastname, StringComparison.InvariantCultureIgnoreCase)))    
    .ToList();
            sw.Stop();
            Console.WriteLine("Time elapsed: {0}", sw.ElapsedTicks);//took 83333ms
            
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            IEnumerable<PersonTwo> difference1 = personTwoList
                .GroupBy(x => new { FirstName = x.firstname.ToLower(), LastName = x.lastname.ToLower() })
                .Select(x => x.First())
                .Where(x => !personOneList.Any(y => y.name.Equals(x.firstname, StringComparison.InvariantCultureIgnoreCase) && y.surname.Equals(x.lastname, StringComparison.InvariantCultureIgnoreCase)));
            sw1.Stop();
            Console.WriteLine("Time elapsed: {0}", sw1.ElapsedTicks);//took 9ms
            Console.ReadLine();
