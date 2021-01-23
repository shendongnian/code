    context.FormData.Attach(sampleFormClass);
    var entry = context.Entry(sampleFormClass);
    entry.State = System.Data.Entity.EntityState.Modified;
    entry.Property(e => e.Items).IsModified = false;
    foreach (var navigationProperty in myTestClass.Test)
    {
           var entityEntry = context.Entry(navigationProperty);
           entityEntry.State = System.Data.Entity.EntityState.Modified;
           entityEntry.Property(navProp => navProp.SampleClassId).IsModified = false;
    }
    }
    context.SaveChanges();
