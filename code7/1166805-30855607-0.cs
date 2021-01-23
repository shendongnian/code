     myPane2.Y2Axis.IsVisible = true;
     myPane2.Y2Axis.Title = cbo_Instrument_3.Text;
     zedGraphControl2.AxisChange();
     LineItem myCurve = myPane2.AddCurve("",inst3time, Color.Blue, SymbolType.Circle);
     myCurve.IsY2Axis = true;
     zedGraphControl2.AxisChange();
     zedGraphControl2.Refresh();
