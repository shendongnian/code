    var startDate = new DateTime(2016, 01, 01);
    foreach (var iteration in Enumerable.Range(0, 10))
    {
        var thisMonth = startDate.AddMonths(iteration);
        foreach (var person in people)
        {
            var invitee = people.FirstOrDefault(potential =>
                        
                // can't have tea alone
                potential.Id != person.Id &&                        
                !matches.Any(previous =>
                    // can't party more than once per month
                    (previous.Date == thisMonth && previous.Contains(person, potential)) ||
                    // can't have tea with same person within 6 months
                    (previous.Date >= thisMonth.AddMonths(-6) &&  
                    (
                        previous.Contains(person) && previous.Contains(potential)
                    ))));
            if (invitee != null)
            {
                var party = new TeaParty(thisMonth, person, invitee);
                matches.Add(party);
                Console.WriteLine(party);
            }
        }
        Console.WriteLine("Press ENTER to process the matches for the next month");
        Console.ReadLine();
    }
