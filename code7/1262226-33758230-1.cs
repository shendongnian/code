    if (decimal.TryParse(txtFeet.Text, out Feet))
    {
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
        else
        {
            CostPerFoot = 0;
        }
    
        //Calculate and display the cost estimate
        CostEstimate = Feet * CostPerFoot;    
        lblTotal.Text = CostEstimate.ToString("C");       
    }
