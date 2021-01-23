    foreach (TableCell item in tableRow.Cells)
    {
         foreach (Control cntrl in item.Controls.Cast<Control>().Where(cntrl => cntrl.GetType() == typeof (TextBox)))
          {
               ((TextBox) cntrl).Text = string.Empty;
          }
    }
    tableRow.Visible = false; //Dont forget to hide the row before you exit
