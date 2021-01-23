    using (var context = new SchoolEntities()) {
      Console.WriteLine("Books full query load");
      var pupil = context.Pupils.First();
      context.Entry(pupil).Collection(p => p.Books).Query().Load();
      // output statements omitted...
    }
    using (var context = new SchoolEntities()) {
      Console.WriteLine("SchoolclassCodes full query load");
      var pupil = context.Pupils.First();
      context.Entry(pupil).Collection(p => p.SchoolclassCodes).Query().Load();
      // output statements omitted...
    }
