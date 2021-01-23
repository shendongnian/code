    Dictionary<string, Panel> panels = new Dictionary<string, Panel>();
    for (i = 0; i <= 10; i++) {
    	Panel pnl = new Panel();
    	panels.Add("pnl" + i.ToString(), pnl);
    }
    //write code against panels
    panels("pnl0").Width = 100;
