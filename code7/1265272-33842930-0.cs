    using (var context = new DatabaseContext())
    {
           var xd = (from c in context.CHall
                              orderby c.CinemaHallName
                              select c).ToList();
            cbCinemaHall.ItemsSource = xd;
            cbCinemaHall.DisplayMemberPath = "CinemaHallName"; 
    }
