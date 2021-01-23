    List<Button> lstBtnCalc = new List<Button>();
    for (int x = 0; x < 10; x++)
    {
        var buttonName = string.Format("btnCalc{0}",x);
        var button = this.Controls.Find(buttonName);
    
        if (button != null)
        {
            lstBtnCalc.Add(button);
        }
    }
