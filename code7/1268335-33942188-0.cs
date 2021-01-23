    public void update(details newData)
    {
    var result=ctx.details.Find(id);
    result.name=newData.Name;
    result.age=newData.Age;
    ctx.SaveChanges();
    }
 
