	public List<FindEmployee_Result> SearchEmployees(string lastName, string employeeID, string securityID)
	{
		using (var ctx = new TestSelectionEntities())
		{
			return ctx.FindEmployee(lastName,employeeID,securityID).ToList();
		}
	}
