    // SQL
    var familiesChildrenAndPets = client.CreateDocumentQuery<dynamic>(collectionLink,
            "SELECT f.id as family, c.FirstName AS child, p.GivenName AS pet " +
            "FROM Families f " +
            "JOIN c IN f.Children " +
            "JOIN p IN c.Pets " +
            "WHERE p.GivenName = 'Fluffy'");
    
    // LINQ
    var familiesChildrenAndPets = client.CreateDocumentQuery<Family>(collectionLink)
            .SelectMany(family => family.Children
            .SelectMany(child => child.Pets
            .Where(pet => pet.GivenName == "Fluffy")
            .Select(pet  => new
            {
                family = family.Id,
                child = child.FirstName,
                pet = pet.GivenName
            }
            )));
