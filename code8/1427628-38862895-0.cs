	// add to top of file
	using System.Data.Objects.SqlClient;
	// code
	var today = DateTime.Now.Date;
	var blogs1 = from c in context.Meal
				where c.PersonID == id
				&& SqlFunctions.DateDiff("D", today, c.Datetime) <= 7
				select c;
	List<Meal> blogs = blogs1.ToList();
