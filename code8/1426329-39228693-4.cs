    var thing = holder.Thing;
    holder.Thing = myOldThing; // for example new Thing() {Id = 2} works
    var attachedHolder = context.Holders.Attach(holder);
    attachedHolder.Thing = thing;
    context.Entry(holder).Property("Some").IsModified = true;
    context.SaveChanges();
