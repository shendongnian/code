    [Test]
    public void NullParamTest()
    {
    	_connection.Execute(@"drop table foo; 
    						  create table foo(id int not null,price decimal(12, 4) null)");
    	_connection.Execute("insert into foo values(1, null)");
    	_connection.Execute("insert into foo values(2, 12.99)");
    
    	const string sql = @"select price from foo 
    						where coalesce(price, -1) = coalesce(@Price, -1)";
    
    	var result = _connection.Query<decimal?>(sql,new { Price = (decimal?)null }).FirstOrDefault();
    	Assert.That(result, Is.Null);
    
    	result = _connection.Query<decimal?>(sql,new { Price = 12.99 }).FirstOrDefault();
    	Assert.That(result, Is.EqualTo(12.99));
    }
