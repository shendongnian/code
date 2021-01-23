    // Configuring mapping. Needs to be done only once.
    Mapper.CreateMap<Customer, Customer>();
    var entity = context.Customers.SingleOrDefault(c => c.CustomerID == 1);
    // Check if entity is null
    var updatedEntity = CustomExtensions.ShallowCopyEntity<Customer>(old);
    updatedEntity.Name = "Modified";
    updatedEntity.MobileNo = "9999999999";
    // Copy the updated values back
    Mapper.Map(updatedEntity, entity);
    context.SaveChanges();
