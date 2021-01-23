    if (Decimal.Parse(txtBudget.Text) >= Decimal.Parse(txtCost.Text))
    {
        btnSubmit.Visible = true;
    }
    else
    {
        btnSubmit.Visible = false;
    }
              
