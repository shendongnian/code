    var query = db.Customers
                  // Project to just the properties we need
                  .Select(c => new { c.FirstName, c.LastName })
                  // Perform the rest of the query in-process
                  .AsEnumerable()
                  .Select(c => $"{c.FirstName} {c.LastName}");
