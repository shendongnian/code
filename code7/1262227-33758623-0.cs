       //Determine cost per foot of wood
        if (radPine.Checked)
        {
            CostPerFoot = PineCost;
        }
        else if (radOak.Checked)
        {
            CostPerFoot = OakCost;
        }
        else if (radCherry.Checked)
        {
            CostPerFoot = CherryCost;
        }
      results in CostPerFoot not to be set (aka none of the three text boxes were set).
