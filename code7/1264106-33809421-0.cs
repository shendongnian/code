    [Test]
    public void CanQueryByDate()
	{
	    var x = (from o in db.Orders
		    where o.OrderDate.Value.Date == new DateTime(1998, 02, 26)
		    select o).ToList();
		Assert.AreEqual(6, x.Count());
	}
