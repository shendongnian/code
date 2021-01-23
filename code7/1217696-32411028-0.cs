    //for verification
    
    var cell=GetCell(2,1);
    
    //Now you can use the assert class for verification
    
    Assert.areequal("CodedUi ", cell.innertext,"values are not matched");
    
    HtmlCell GetCell(UITestControl parent, int row, int column)
    { 
      var cell= new htmlcell(parent);
      cell.Searchproperties.Add(HtmlCell.Propertynames.Rowindex,row);
      cell.Searchproperties.Add(HtmlCell.Propertynames.Columnindex,column);
       retun cell;
    }
