    private static void OrderByAndWhereUsingEntitySQL_AndQueryBuilderMethods()
    {
        using (var context = new AWEntities())
        {//using Entity SQL with helper Query Builder Methods
            //dbContext does not have a Where method that accepts esql string statements
            //get to the dbContext's ObjectContext class
            var objectContext = (context as IObjectContextAdapter).ObjectContext;
            //now we can use the Where method that understands esql string statements
            var query = objectContext.CreateObjectSet<Customer> ().Where("it.FirstName='Robert'").OrderBy("it.LastName");
            //execute the query
            var customers = query.ToList();
            foreach (var cust in customers)
                Debug.WriteLine(cust.LastName.Trim() + ", " + cust.FirstName);
        }
    }
