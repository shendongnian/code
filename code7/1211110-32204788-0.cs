    class ProductionStep
    {
      public string name;
      public decimal calculatCosts()
      { 
        return 100;
      }
    }
    List<ProductionStep> listOfAllProductionstep;
    private void button5_Click(object sender, EventArgs e)
    {
      List<ProductionStep> psList = new List<ProductionStep>();
      psList.Add(listOfAllProductionstep.Find(o => o.name == "Abc"));
      psList.Add(listOfAllProductionstep.Find(o => o.name == "Def"));
      decimal totalCosts = 0;
      foreach (ProductionStep ps in psList)
        totalCosts += ps.calculatCosts();
    }
