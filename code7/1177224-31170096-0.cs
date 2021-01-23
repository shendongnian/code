    public Unit GetParentUnitThatIsInCharge(Unit unit)
    {
        Unit inChargeUnit= null;
    
        if (unit.Parent != null)
        {
            do
            {
                inChargeUnit= unit.Parent;
            } while (!inChargeUnit.IsInCharge);
        }
    
        unit.ParentUnitThatIsInCharge = inChargeUnit;
        return inChargeUnit;
    }
