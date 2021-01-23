    using (var context = new SchoolEntities()) {
      Console.WriteLine("Books direct load");
      var pupil = context.Pupils.First();
      context.Entry(pupil).Collection(p => p.Books).Load();
      Console.WriteLine("  IsLoaded = " + context.Entry(pupil).Collection(p => p.Books).IsLoaded);
      Console.WriteLine("  Items in the pupil:");
      foreach (var item in pupil.Books)
        Console.WriteLine("    " + item.Id);
      Console.WriteLine("  Items in the context:");
      foreach (var item in context.Books.Local)
        Console.WriteLine("    " + item.Id);
    }
    using (var context = new SchoolEntities()) {
      Console.WriteLine("SchoolclassCodes direct load");
      var pupil = context.Pupils.First();
      context.Entry(pupil).Collection(p => p.SchoolclassCodes).Load();
      Console.WriteLine("  IsLoaded = " + context.Entry(pupil).Collection(p => p.SchoolclassCodes).IsLoaded);
      Console.WriteLine("  Items in the pupil:");
      foreach (var item in pupil.SchoolclassCodes)
        Console.WriteLine("    " + item.Id);
      Console.WriteLine("  Items in the context:");
      foreach (var item in context.SchoolclassCodes.Local)
        Console.WriteLine("    " + item.Id);
    }
