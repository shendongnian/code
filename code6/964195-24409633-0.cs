    public Unit Subtract(this Unit unit, Unit toSubtract)
    {
        if (unit.Type != toSubtract.Type)
            throw new InvalidOperationException("Types are not compatible");
    
        return new Unit(unit.Value - toSubtract.Value, 
           unit.Type);
    }
    
    ...
    
    control1.Width = control2.Width.Subtract(control3.Width);
