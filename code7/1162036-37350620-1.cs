    // using Z.EntityFramework.Plus; // Don't forget to include this.
    
    var ctx = new EntityContext();
    // ... ctx changes ...
    
    var audit = new Audit();
    audit.CreatedBy = "ZZZ Projects"; // Optional
    ctx.SaveChanges(audit);
    
    // Access to all auditing information
    var entries = audit.Entries;
    foreach(var entry in entries)
    {
        foreach(var property in entry.Properties)
        {
        }
    }
