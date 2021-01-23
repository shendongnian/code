    public ActionResult Search(Guid apiKey, SearchParams p)
    {
        try
        {
            if (p.UsePerson)
            {
                using (var service = new ServicePerson())
                {
                    List<Person> result = service.Search(p);
                    return XmlResult(result, "PersonList.xml");
                }
            }
            using (var service = new ServiceEmployee())
            {
                List<Employee> result = service.Search(p);
                return XmlResult(result, "EmployeeList.xml");
            }
        }
        catch (Exception ex)
        {
            // log error
        }
    }
