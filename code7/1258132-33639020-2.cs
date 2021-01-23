    Console.Write("Enter a year: ");
    int year = int.Parse(Console.ReadLine());
    int maxYearsBack = 2;
    
    var months = Enumerable.Range(1, 12).Where(m =>
        (DateTime.Today.Year == year && m <= DateTime.Today.Month) || // This year
        (DateTime.Today.Year != year && (DateTime.Today.Year - year < maxYearsBack || m - DateTime.Today.Month >= 0)) // Middle and max years back
    ).Select(x => x.ToString());
    
    Console.WriteLine("Months for year {0}: {1}", year, String.Join(", ", months));
