    Decimal budget;
    Decimal cost;
    
    if (!Decimal.TryParse(txtBudget.Text, out budget)) {
      btnSubmit.Visible = false; 
      //TODO: probably you have to show message that txtBudget has incorrect value
    }
    else if (!Decimal.TryParse(txtCost.Text, out cost)) {
      btnSubmit.Visible = false; 
      //TODO: probably you have to show message that txtCost has incorrect value
    }
    else {
      //TODO: you may find useful to check if cost < 0 or/and budge < 0 etc.
      btnSubmit.Visible = budget >= cost;  
    }
