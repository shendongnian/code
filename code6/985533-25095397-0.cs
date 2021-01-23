    // GET: api/Expenses
    [Route("api")]
    public IQueryable<Expense> GetExpenses()
    {
        return db.Expenses;
    }
    // GET: api/Expenses/5
    [Route("api/{id}"]
    [ResponseType(typeof(Expense))]
    public async Task<IHttpActionResult> GetExpense(string id)
    {
        Expense expense = await db.Expenses.FindAsync(id);
        if (expense == null)
        {
            return NotFound();
        }
        return Ok(expense);
    }
