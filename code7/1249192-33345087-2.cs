            var John = new { Salary = 1000, Bonus = 200 };
            var Michal = new { Salary = 1500, Bonus = 0 };
            var dict = new Dictionary<string, dynamic>()
            {
                {"John", John},
                {"Michal", Michal},
            };
            Console.WriteLine(dict["John"].Bonus);
