    for(int r = 1; r < 10; r++)
       {
          for(int c = 1; c < 10; c++)
             {
                intResult = r * c;
                if (intResult < 10)
                strSpace = "  ";  //two spaces 
                else
                strSpace = " ";   //one space
                txtTable.AppendText(strSpace); // insert space
                txtTable.AppendText(intResult.ToString());  //insert result
             }
          txtTable.AppendText("\r\n");  //Move down one line
       }
