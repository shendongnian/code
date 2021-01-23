    var code = new SchoolclassCode { Id = 1 };
    context.SchoolclassCodes.Attach(code);
    var objectStateManager = ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager;
    objectStateManager.ChangeRelationshipState(pupil, code, p => p.SchoolclassCodes, EntityState.Deleted);
    context.SaveChanges();
