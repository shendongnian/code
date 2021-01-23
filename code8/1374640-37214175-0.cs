    class Person
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            List<Person> people =
                lines
                    .Select((line, index) =>
                        new
                        {
                            Index = index / 2,
                            RawData = line
                        }
                    )
                    .GroupBy(obj => obj.Index)
                    .Select(group =>
                        {
                            var rawPerson = group.ToArray();
                            string name = rawPerson[1].RawData;
                            string[] rawDetails = rawPerson[0].RawData.Split('|');
                            return
                                new Person()
                                {
                                    Name = name,
                                    City = rawDetails[0],
                                    Country = rawDetails[1],
                                    PhoneNumber = rawDetails[2]
                                };
                        }
                    )
                    .ToList();
        }
    }
