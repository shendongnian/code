    void Start(){
        InvokeRepeating("Method", 3f, 3f);
    }
    void Method(){
         foodTotal += foodPtick;
         PowerTotal += PowerPtick;
         HappinessTotal += HappinessPtick;
         MoneyTotal += MoneyPtick;
         PopulationTotal += PopulationPtick;
         Debug.Log("Resources" + "food" + foodTotal + "power" + PowerTotal + "Happiness" + HappinessTotal + "Money" + MoneyTotal + "Population" + PopulationTotal);
    }
