    using(var context = new MyEDM())
    {
        Console.WriteLine("Save Starting");
        context.MyTable.AddRange(myList);
        await context.SaveChangesAsync();
        Console.WriteLine("Save Complete");
    }
