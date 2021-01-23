    public ActionResult SubmitExpenses(int[] expenseIDs, DateTime? expenseDate = null, DateTime? expenseDate2 = null, int? userId = 0)
        {
            expenseDate = (DateTime)Session["FirstDate"];
            expenseDate2 = (DateTime)Session["SecondDate"];
            if (expenseDate == null || expenseDate2 == null)
            {
                expenseDate = DateTime.Now.AddMonths(-1);
                expenseDate2 = DateTime.Today;
            }
            string currentUserId = User.Identity.Name;
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
            //var localExpenseIDs = expenseIDs;
            var joined = from dbExpense in query.Select(x => x.e).AsEnumerable()
                         join localExpense in expenseIDs on dbExpense.ExpenseId equals localExpense
                         where localExpense == dbExpense.ExpenseId
                         select dbExpense;
            foreach (Expense exp in joined)
            {
                exp.DateSubmitted = DateTime.Today;
                exp.IsSubmitted = true;
            }
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Submit");
            }
        }
