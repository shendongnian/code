    public ActionResult Statement(int checkingAccountId, int page = 1, int pageSize = 4)
    {
        var checkingAccount = db.CheckingAccounts.Find(checkingAccountId);
        List<Transaction> statement = checkingAccount.Transactions.ToList();
        ViewBag.CheckingAccountId = checkingAccountId;
        PagedList<Transaction> model = new PagedList<Transaction>(statement, page, pageSize);
        return View(model);
    }
