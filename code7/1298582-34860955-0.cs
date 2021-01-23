    IQueryable<Boxes> boxes = dbContext.Boxes;
    if(this.Customer != null)
       boxes= boxes.Where(box => box.CurrentCustomer == this.Customer);    
    if(this.IDs != null)
        boxes=boxes.Where(box => this.IDs.Split(',').Any(id => id == box.ID.ToString())); 
    //...
