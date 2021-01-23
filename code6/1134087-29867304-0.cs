    var result = personOneList.Join
                 (
                    personTwoList, 
                    person1 => new { Key1 = person1.Name, Key2 = person1.Surname }, 
                    person2 => new { Key1 = person2.FirstName, Key2 = person2.LastName }, 
                    (person1, person2) => new PersonOnePersonTwo { PersonOneId = person1.Id, PersonTwoId = person2.Id }
                 ).ToList();
