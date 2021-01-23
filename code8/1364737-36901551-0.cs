    var homes = ctx.Homes;
    if (cmbRentAmount.Text != "All") {
      homes = homes.Where(h => h.RentAmount == cmbRentAmount.Text);
    }
    // Similar for the other two combos
    // ...
    // Now we enumerate the query, which does the actual database access
    var homesList = homes.ToList();
