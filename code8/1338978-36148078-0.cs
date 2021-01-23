    //initiate with default values
    int ThreCol = 0;
    int ResCol = 0;
    
    //try parsing
    Int32.TryParse(e.Row.Cells[3].Text, out ThreCol);
    Int32.TryParse(e.Row.Cells[4].Text, out ResCol);
