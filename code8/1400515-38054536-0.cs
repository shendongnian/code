    var cars = Session.CreateCriteria<Car>("c");
    
    var c = DetachedCriteria.For<Employee>("emp")
       // join
       .CreateCriteria("emp.Company", "comp")
       // select company id
       .SetProjection(Projections.Property("comp.id"))
       // of all companies where the employee is working in.
       .Add(Restrictions.Eq("emp.Id", employee.Id));
    
    carCompanies.Add(Subqueries.PropertyIn("comp.Id", c));
