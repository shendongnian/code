        if (ModelState.IsValid)
        {
            expense.UserId = HttpContext.Current.User.Identity.Name;  // or whatever
            db.Expenses.Add(expense);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
