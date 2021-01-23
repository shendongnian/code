	// GET: Account Movements
	public ActionResult Movements(int? id) {
		if (id == null) {
			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
		Account account = db.Accounts.Find(id);
		if (account == null) {
			return HttpNotFound();
		}
		//-- BEGIN SAMPLE DATA - DELETE WHEN YOU HAVE DATABASE FILLED
		var accounts = new List<Account> {
			new Account {Id = 1, Name = "Account 1"}
		};
		account = accounts.First();
		var profits = new List<Profit> {
			new Profit {Id = 1, Account_Id = 1, Value = 20, Description = "Profit 1", Date = DateTime.Now.AddMinutes(-60)},
			new Profit {Id = 2, Account_Id = 1, Value = 30, Description = "Profit 2", Date = DateTime.Now.AddMinutes(-120)},
			new Profit {Id = 3, Account_Id = 1, Value = 60, Description = "Profit 3", Date = DateTime.Now.AddMinutes(-180)},
		};
		account.Profits = profits;
		var expenses = new List<Expense> {
			new Expense {Id = 1, Account_Id = 1, Value = 10, Description = "Expense 1", Date = DateTime.Now.AddMinutes(-30)},
			new Expense {Id = 2, Account_Id = 1, Value = 40, Description = "Expense 2", Date = DateTime.Now.AddMinutes(-90)},
			new Expense {Id = 3, Account_Id = 1, Value = 200, Description = "Expense 3", Date = DateTime.Now.AddMinutes(-150)},
		};
		account.Expenses = expenses;
		//-- END SAMPLE DATA
		//-- BEGIN Fill Movements
		var movements = new List<Movement> { };
		foreach (Profit p in account.Profits) {
			var m = new Movement { Id = p.Id, Value = p.Value, Description = p.Description, Type = "Profit", Date = p.Date };
			movements.Add(m);
			//-- Add Profits sum to Balance
			account.Balance += p.Value;
		}
		foreach (Expense e in account.Expenses) {
			var m = new Movement { Id = e.Id, Value = e.Value, Description = e.Description, Type = "Expense", Date = e.Date };
			movements.Add(m);
			//-- Add Expenses sum to Balance
			account.Balance -= e.Value;
		}
		account.Movements = movements.OrderByDescending(x => x.Date).ToList();
		//-- END Fill Movements
		ViewBag.AccountName = account.Name;
		ViewBag.AccountBalance = account.Balance;
		return View(account.Movements);
	}
