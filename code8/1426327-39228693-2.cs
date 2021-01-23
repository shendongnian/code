    var thing = holder.Thing;
    holder.Thing = null;
    var attachedHolder = context.Holders.Attach(holder);
    attachedHolder.Thing = thing;
    context.Entry(holder).Property("Some").IsModified = true;
    context.SaveChanges();
