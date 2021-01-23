    var pupil = context.Pupils.First();
    var schoolclassCodeId = 1;
    await context.Entry(pupil).Collection(p => p.SchoolclassCodes).Query().Where(s => s.Id == schoolclassCodeId).LoadAsync();
    Console.WriteLine("IsLoaded = " + context.Entry(pupil).Collection(p => p.SchoolclassCodes).IsLoaded);
    foreach (var code in pupil.SchoolclassCodes)
      Console.WriteLine("  " + code.Id);
