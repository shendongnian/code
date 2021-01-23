    using (var context = new SchoolEntities()) {
      Console.WriteLine("Books partial query load");
      var pupil = context.Pupils.First();
      context.Entry(pupil).Collection(p => p.Books).Query().Where(s => s.Id == 1).Load();
      Console.WriteLine("  IsLoaded = " + context.Entry(pupil).Collection(p => p.Books).IsLoaded);
      Console.WriteLine("  Items in the pupil:");
      foreach (var item in pupil.Books)
        Console.WriteLine("    " + item.Id);
      Console.WriteLine("  Items in the context:");
      foreach (var item in context.Books.Local)
        Console.WriteLine("    " + item.Id);
    }
    using (var context = new SchoolEntities()) {
      Console.WriteLine("SchoolclassCodes partial query load");
      var pupil = context.Pupils.First();
      context.Entry(pupil).Collection(p => p.SchoolclassCodes).Query().Where(s => s.Id == 1).Load();
      Console.WriteLine("  IsLoaded = " + context.Entry(pupil).Collection(p => p.SchoolclassCodes).IsLoaded);
      Console.WriteLine("  Items in the pupil:");
      foreach (var item in pupil.SchoolclassCodes)
        Console.WriteLine("    " + item.Id);
      Console.WriteLine("  Items in the context:");
      foreach (var item in context.SchoolclassCodes.Local)
        Console.WriteLine("    " + item.Id);
    }
