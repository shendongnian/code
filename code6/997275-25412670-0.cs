    class Program
    {
        private const string sample =
                             @"<Main>
                                   <Person>
                                   <Name>John Smith</Name>
                                   <Age>25</Age>
                                   <Position>Junior accountant</Position>
                               </Person>
                               <Person>
                                   <Age>33</Age>
                                   <Position>Consultant</Position>
                               </Person>
                               <Person>
                                   <Name>Manfred</Name>
                                   <Age>45</Age>
                                   <Position>Manager</Position>
                                </Person>
                                <Person>
                                    <Age>99</Age>
                                    <Position>The Chairman</Position>
                                </Person>
                            </Main>";
        static void Main(string[] args)
        {
            var xml = XElement.Parse(sample);
            var noNamePersons = xml.Elements("Person")
                                   .Where(e => !e.Elements("Name").Any());
            foreach (var person in noNamePersons)
            {
                person.Add(new XElement("Name", "A name should be placed here"));
            }
            Console.WriteLine(xml);
            Console.ReadLine();
        }
    }
