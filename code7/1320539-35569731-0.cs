    mockContactNumberRepository
    .Setup(x => 
    	x
    	.GetAll(
    		It.IsAny<Expression<Func<ContactNumber, bool>>>(), 
    		It.IsAny<Func<IQueryable<ContactNumber>, IOrderedQueryable<ContactNumber>>>(),
    		It.IsAny<string>()))
    .Returns(new Func<
    	Expression<Func<ContactNumber, bool>>, 
    	Func<IQueryable<ContactNumber>, IOrderedQueryable<ContactNumber>>,
    	string,
    	IEnumerable<TEntity>>((arg1, arg2, arg3) => 
    		{
    			// arg1 is Expression<Func<ContactNumber, bool>>
    			// arg2 is Func<IQueryable<ContactNumber>, IOrderedQueryable<ContactNumber>>
    			// arg3 is string
    			// Do something here and return an IEnumerable<TEntity>
    		}));
