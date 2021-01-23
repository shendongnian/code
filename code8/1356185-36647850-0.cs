    public void search(IEnumerable<string> Location)
    {
        Dictionary<Location, List<Students>> newStudents = new  Dictionary<Location, List<Students>>();
        foreach (var l in Location)
        {
            var students = from s in db.Students select s;
            students = students.Where(s => s.City.Contains(l));
            newStudents[l]= students.ToList();                  
         }
         int custIndex = 1;
        //what is this for?  seeing lastly added 
         Session["TopEventi"] = customers.ToDictionary(x => custIndex++, x => x);
         ViewBag.TotalNumberCustomers = (from  lists in newStudents select  lists.Count).Sum();
