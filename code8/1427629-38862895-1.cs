	// add to top of file
	using System.Data.Entity;
	// code
	var today = DateTime.Now.Date;
	var blogs1 = from c in context.Meal
				where c.PersonID == id
				&& DbFunctions.DiffDays(today, c.Datetime) <= 7
				select c;
	List<Meal> blogs = blogs1.ToList();
