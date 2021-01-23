    Public Function SearchFor(Of TSource As Class)(predicate As System.Linq.Expressions.Expression(Of System.Func(Of TSource, Boolean))) As IQueryable(Of TSource)
    	Dim query = (From objects In _dataStore Where TypeOf objects Is TSourceobjects).[Select](Function(o) DirectCast(o, TSource)).AsQueryable()
    
    	Return query.Where(predicate)
    End Function
