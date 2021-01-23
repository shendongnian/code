    private decimal cost;
    public decimal Cost
    {
        get
        {   
            cost = CalculateCostOfDecorations() + (CalculateCostOfBeveragesPerPerson() + CostOfFoodPerPerson) * NumberOfPeople; 
            if (HealthyOption)
            {
                cost *= .95M;
            }
            return cost;
        }
    }
    public decimal CalculateDiscountedCost() {
         return cost * 0.75m; //Note the deliberate mistake?
    }
