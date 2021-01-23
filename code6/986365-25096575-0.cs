    DateTime? function( DateTime? a, DateTime? b ){
        if(!a.HasValue && !b.HasValue)
            throw new ArgumentNullException();
        else if(!a.HasValue)
            return b;
        else if(!b.HasValue)
            return a;
        
        return a.Value < b.Value ? a : b;
    }
