    bool endReach=false;    
    for (int j = 1; !endReach; j++)
        {
          if(excel_getValue("A"+j).value == "" && excel_getValue("A"+(j+1)).value == "")
          {
                 endReach=true;
           }else{
                 list.add(excel_getValue("A"+j)); //ROW A in excel
           }
        }
