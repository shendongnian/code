    class Mode
    {
        public double Distance;
        public string Name;
        public Mode( double d, string n ) { this.Distance = d; this.Name = n; }
    }
    string Func( int mode, double distance )
    {
        Mode[] modes;
        if( mode == 1 )
            modes = new Mode[] { new Mode( 4000, "1F" ),
                                 new Mode( 8000, "2F" ),
                                 new Mode( 12000, "3F" ),
                                 new Mode( double.MaxValue, "F 0-5" ) };
        else
            modes = new Mode[] { new Mode( 500, "" ),
                                 new Mode( 4000, "2F" ),
                                 new Mode( 8000, "3F" ),
                                 new Mode( 12000, "4F" ),
                                 new Mode( double.MaxValue, "F 0-5" ) };
        for( int pos = 0; ; pos++ )
            if( distance <= modes[pos].Distance )
                return modes[pos].Name;
    }
