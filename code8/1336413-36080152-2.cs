    var licenses = context.LicenseUsers
      .Include(lu => lu.License.Product)
      .Where(lu => lu.User.Id == 1)
      .Select(lu => new { lic = lu.License, prod = lu.License.Product } )
	  .AsEnumerable()  // Here we have forced the SQL to include the product too
	  .Select(lu => lu.lic)
      .ToList(); // Then we select (locally) only the license for convenience 
                 // (so that our collection is of type License)
                 // Since the SQL Query actually loaded the products
                 // the references will be ok
