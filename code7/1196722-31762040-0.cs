    private void addButtonNumberToResult(Button btn)  //helper method 
    {
        if (btnClicked == true)
        {
            btnTotal.Text = "";
            btnClicked = false;
        }
        QuantityResult = QuantityResult += btn.Content;
        btnTotal.Text = QuantityResult;
    }
