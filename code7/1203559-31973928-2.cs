    class Rule
    {
        public string Key;
        public float Min, Max;
    }
    private Rule[] m_RulesCase1 = new Rule[]
                                  {
                                      new Rule() { Key = "ph", Max = 5.72, Min = 4.75 }
                                      new Rule() { Key = "brix", Max = 22.36, Min = 17.35 }
                                      ...
                                  };
    private void ApplyRule( GridDataItem dataBoundItem, Rule r )
    {
        float f = float.Parse( dataBoundItem[r.Key].Text );
        if( f > r.Max || f < r.Min )
        {
             dataBoundItem[r.Key].BackColor = Color.Yellow;
             dataBoundItem[r.Key].ForeColor = Color.Black;
             dataBoundItem[r.Key].Font.Bold = true;
        }
    }
    private void ApplyRules( GridDataItem dataBoundItem, IEnumerable<Rule> rules )
    {
        foreach( var r in rules )
            ApplyRule( dataBoundItem, r );
    }
