    using(var context = new MyContext())
    {
        A objA = context.As.Find(id); // id is a variable holding an existing A's Id
        // Now objA is attached to the context and won't be added.
        B objB = new B() { Name = "Object B", A = objA };
        context.Bs.Add(objB);
        context.SaveChanges();
    }
