     var subTotal = 0;
     for (int r = 0; r < dg.Rows.Count; r++)
      {
          oTable.Cell(j, 1).Range.Text = iPos.ToString();
          oTable.Cell(j, 2).Range.Text = Number.ToString();
          oTable.Cell(j, 3).Range.Text = Name.ToString();
          oTable.Cell(j, 4).Range.Text = UnitPrice.ToString();
          oTable.Cell(j, 5).Range.Text = Sum.ToString();
          j += 3;
          iPos++;
    
         //Every 10th row is a subtotal (because you do 3 row jumps j+=3)  
         subtotal+=Sum;
         if ((j % 3 * 10) == 0) {
               var currentRow = oTable.Rows[j];
               //Insert after this row
               var subtotalRow = oTable.Rows.Add(currentRow)
               subtotalRow.Cells[5].Range.Text = subtotal.ToString();
               subtotal = 0;
         }
      }
