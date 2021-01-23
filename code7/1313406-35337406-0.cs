     public List<Person> People()
        {
            using (var context = new SewerMaintenanceEntities())
            {
                return context.People
                    .Select(p=> p)
                    .Include(p=>p.PeopleXAddresses)
                    .ToList();
            }
        }
