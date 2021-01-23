    var query = from e in db.Expenses
                join user in db.UserProfiles on e.UserId equals user.UserId
                where e.ExpenseDate >= expenseDate && e.ExpenseDate <= expenseDate2 && e.DateSubmitted == null
                orderby e.ExpenseDate descending
                select new { e, user };
    if (User.IsInRole("admin") && userId != 0)
    {
        query = query.Where(x => x.user.UserId == userId);
    }
    else if (!User.IsInRole("admin"))
    {
        query = query.Where(x => x.user.UserName == currentUserId);
    }
    
