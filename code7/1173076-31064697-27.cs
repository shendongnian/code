    using (var context = new SchoolEntities()) {
      Console.WriteLine("Books side load");
      var pupil = context.Pupils.First();
      context.Books.Where(s => s.Pupil.Id == pupil.Id).Load();
      // output statements omitted...
    }
    using (var context = new SchoolEntities()) {
      Console.WriteLine("SchoolclassCodes side load");
      var pupil = context.Pupils.First();
      context.SchoolclassCodes.Where(s => s.Pupils.Select(t => t.Id).Contains(pupil.Id)).Load();
      // output statements omitted...
    }
