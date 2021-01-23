    public decimal GetCost()
    {
        cost = CalculateCostOfDecorations() + (CalculateCostOfBeveragesPerPerson() + CostOfFoodPerPerson) * NumberOfPeople; 
        if (HealthyOption)
        {
            cost *= .95M;
        }
        return cost;
    }
