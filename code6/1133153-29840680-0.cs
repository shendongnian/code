            var masterList = new List<Student>
                                {
                                    new Student {RollNumber = 1, Name = "Jim", Division = "A"},
                                    new Student {RollNumber = 10, Name = "Mike", Division = "A"},
                                    new Student {RollNumber = 8, Name = "Peter", Division = "A"},
                                    new Student {RollNumber = 4, Name = "Sandy", Division = "A"},
                                    new Student {RollNumber = 7, Name = "Michale", Division = "A"}
                                };
            var subList = new List<Student>
                                {
                                    new Student {RollNumber = 4, Name = "Sandy", Division = "A"},
                                    new Student {RollNumber = 7, Name = "Michale", Division = "A"},
                                    new Student {RollNumber = 1, Name = "Jim", Division = "A"},
                                    new Student {RollNumber = 10, Name = "Mike", Division = "A"}
                                };
            List<Student> sortedList = new List<Student>();
            foreach (var item in masterList.Select(x => x.RollNumber))
            {
                if (subList.Where(x => x.RollNumber == item).FirstOrDefault() != null)
                    sortedList.Add(subList.Where(x => x.RollNumber == item).First());
            }
