    if (group.Members == null)
                {
                    group.Members = new List<Person>();
                    group.Members.Add(person);
                }
                else {
                    group.Members.Add(person);
                }
