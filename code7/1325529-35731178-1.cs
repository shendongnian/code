    void Update(){
        timer += Time.deltaTime;
        if(timer > waitTime){
           timer = 0f;
           foodTotal += foodPtick;
           PowerTotal += PowerPtick;
           HappinessTotal += HappinessPtick;
           MoneyTotal += MoneyPtick;
           PopulationTotal += PopulationPtick;
           Debug.Log("Resources" + "food" + foodTotal + "power" + PowerTotal + "Happiness" + HappinessTotal + "Money" + MoneyTotal + "Population" + PopulationTotal);
       }
    }
