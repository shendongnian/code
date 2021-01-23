    var row = await Create(item);
    Assert.That(row.FirstName, Is.EqualTo("FirstName"));
    Assert.That(row.FullName, Is.EqualTo("FirstName LastName"));
    row.LastName = "Updated LastName";
    row = await Create(row);
    Assert.That(row.FirstName, Is.EqualTo("FirstName"));
    Assert.That(row.FullName, Is.EqualTo("FirstName Updated LastName"));
