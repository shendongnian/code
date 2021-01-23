    static void Main(string[] args)
        {
            var list =
                System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Select(s => s + " " + DateTime.Today.Year)    // Get now through the end of the year
                        .Skip(DateTime.Today.Month - 1)
                        .Take(12 - (DateTime.Today.Month - 1))
                        .ToList()
                    .Concat(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Select(s => s + " " + DateTime.Today.AddYears(1).Year).Take(12))  // Tack on next year
                    .Concat(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Select(s => s + " " + DateTime.Today.AddYears(2).Year)    // Tack on the last months
                        .Take(DateTime.Today.Month - 1))
                        .ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
