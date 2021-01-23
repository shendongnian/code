    <code>
    var emptyInterUsers = db.List<UserEntity>(u => u.Interests == null);
    if (emptyInterUsers.Any())
    {
    	foreach (var u in emptyInterUsers)
    	{
    	    if (u.Interests == null)
    	    {
    	        var filter = db.F<UserEntity>().Eq(f => f.id, u.id);
    	        var update = db.U<UserEntity>().Set(f => f.Interests, new List<int>());
    	        var res = await db.UpdateAsync(filter, update);
    	    }
    	}	                
    }
    </code>
