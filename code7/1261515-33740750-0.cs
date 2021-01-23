    var times = new List<Time>();
    var dbSet = lpcContext.Set<Time>();
    
    foreach( var t in timesVm )
    {
        var time = dbSet.Find( t.Id );
        if( null == time )
        {
            time = Mapper.Map<TimeViewModel, Time>( t );
        }
        times.Add( time );
    }
    
    collaborador.Times = times;
