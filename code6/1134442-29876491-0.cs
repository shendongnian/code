            var HashTable = new Dictionary<Tuple<String,String>,Object>();
            foreach (PersonOne person in personOneList)
            {
                var personTuple = Tuple.Create(person.name, person.surname);
                if (!HashTable.ContainsKey(personTuple))
                {
                    HashTable[personTuple] = person;
                }
            }
            foreach (PersonTwo person in personTwoList)
            {
                var personTuple = Tuple.Create(person.firstname, person.lastname);
                if (!HashTable.ContainsKey(personTuple)) {
                    HashTable[personTuple] = person;
                }
            }
            var myResult = HashTable.Where(x => x.Value is PersonTwo).Select(x => x.Value).Cast<PersonTwo>().ToList();
