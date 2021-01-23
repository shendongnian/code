    using (var context = new MyDbContext())
    {
        // Make your context aware of the object.
        context.Images.Attach(image);
        // Now delete the object. It will change the internal
        // state so that it will be deleted.
        context.Images.Remove(image);
        // Finally, save your changes
        context.SaveChanges();
    }
