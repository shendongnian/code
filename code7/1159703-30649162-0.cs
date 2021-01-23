    using (var context = new SchoolDBEntities())
    {
        try
        {
            context.Entry(student1WithUser2).State = EntityState.Modified;
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("Optimistic Concurrency exception occured");
        }
    }
