    var data = db.Person.Select(person => new { Age = person.Age, Date = person.Date })
                        .OrderByDescending(person => person.Age)
                        .Take(5)
                        .Select(person => new PersonAgeDateItem() {
                            Age = person.Age,
                            Date = person.Date
                        });
    // person.Age, being a string, could pose an issue.. like "2" coming after "19", "199", "1999".. etc etc
