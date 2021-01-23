    var person = new Person();
    person.Id = 1;
    person.Name = ""; // not null string to pass validation
    person.Age = 25;
    var entry = context.Entry(person);
    entry.Property(e => e.Age).IsModified = true;
    context.SaveChanges();
