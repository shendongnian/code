    public double DistanceBetween(IDimension otherPoint)
    {
        if (otherPoint is Dimension<T>)
            return DistanceBetween((Dimension<T>)otherPoint);
        // general implementation, only using what the interface provides
        return 0;
    }
    public double DistanceBetween(Dimension<T> otherPoint)
    {
        return otherPoint.Data - Data; // or whatever
    }
