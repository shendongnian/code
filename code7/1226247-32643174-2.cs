    public override object Clone()
    {
        ParaGridViewColumn c = (ParaGridViewColumn)base.Clone();
    
        c._Necessary = this._Necessary;      
        c._ReadOnlyEmpty = this._ReadOnlyEmpty;            
        return c;
    } 
