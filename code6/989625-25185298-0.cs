    public object Magnitude
        {
            get {
    
                Type typeT = typeof(T);
    
                if (typeT == typeof(Dimension))
                {
                    return base.Length;
                }
                else if (typeT == typeof(ForceUnit))
                {
                    return _magnitudeForce;
                }
    
            ...
        }
