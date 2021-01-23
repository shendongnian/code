    foreach (var city in cities) {
         output = String.Format("{0,-12}{1,8:yyyy}{2,12:N0}{3,8:yyyy}{4,12:N0}{5,14:P1}",
                                city.Item1, city.Item2, city.Item3, city.Item4, city.Item5,
                                (city.Item5 - city.Item3)/ (double)city.Item3);
         Console.WriteLine(output);}
