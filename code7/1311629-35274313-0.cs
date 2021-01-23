    public async Task<YourModelContext> SaveModel(YourModelContext context)
    {
      var existing = await YourTable.FirstOrDefaultAsync(f => f.Id == context.Id);
      if (existing == null)
      {
        existing = new YourDatabaseModel
        {
          Created = DateTime.UtcNow
        }
        YourTable.Add(existing);
      }
      
      // Name will be saved and changed by the user
      // existing.Name = context.Name;
      // existing.Description = context.Description;
      // existing.SomeOtherField = context.SomeOtherField;
      // Not specifying name will not update the name.
      // You'll have to set the readonly on textbox in the web page
      existing.Description = context.Description;
      existing.SomeOtherField = context.SomeOtherField;
      // Save the changes to the underlying database
      await SaveChangesAsync();
      // Assign the inserted database id to the view model id
      context.Id = existing.Id;
      // Return the view model context to the html page
      return context;
    }
