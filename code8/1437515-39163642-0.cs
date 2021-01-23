    var entry = _context.Shops.Update(shop);
    foreach (var property in entry.Entity.GetType().GetTypeInfo().DeclaredProperties)
    {
          var currentValue = entry.Property(property.Name).CurrentValue;
          if (currentValue == null)
                entry.Property(property.Name).IsModified = false;
    }
