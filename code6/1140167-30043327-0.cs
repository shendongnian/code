using(var context = new MyEDM())
{
    context.MyTable.AddRange(myList);
    context.SaveChanges();
}
