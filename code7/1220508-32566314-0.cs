               private int currentPrintingRowIndex = 0;
                private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
{
              Font fsystem = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
              Font fdatabd = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
              Font fdatabdstrikeout = new Font("Arial", 18, FontStyle.Strikeout, GraphicsUnit.Pixel);
              Font fdiag = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Pixel);
              Font fbarra = new Font("C39HrP24DhTt", 30, FontStyle.Regular, GraphicsUnit.Pixel);
              Font fdesc = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Pixel);
               var allCheckedRows = this.dgv1.Rows.Cast<DataGridViewRow>()
                              .Where(row => (bool?)row.Cells[0].Value == true)
                              .ToList();
            if (allCheckedRows.Count > currentPrintingRowIndex)
            {
                var builder = new StringBuilder();
                var currentCheckedRow = allCheckedRows[currentPrintingRowIndex];
                var cellValues = currentCheckedRow.Cells.Cast<DataGridViewCell>()
                        .Where(cell => cell.ColumnIndex > 0)
                        .Select(cell => string.Format("{0}", cell.Value))
                        .ToArray();
                builder.Append(string.Join(",", cellValues));
                //  begin of the aditional implementation
                string ldp = builder.ToString();
                string[] cadaum = ldp.Split(',');
                var cents = cadaum[3].Substring(0, 2);
                var descr = cadaum[1].ToString();
                if (descr.Length >= 30)
                {
                    var descr2 = descr.Substring(0, 30);
                    var descr3 = descr.Substring(30);
             // end of the aditional implementation
             // begin modification
            //UPPER LEFT SIDE
            e.Graphics.DrawString("TRADEMARK", fsystem, Brushes.Black, 45, 8); 
                    e.Graphics.DrawString("COMPANY'S NAME", fdatabd, Brushes.Black, 10, 30);
                    e.Graphics.DrawString("ANY OTHER INFORMATION", fdatabd, Brushes.Black, 10, 41);
                    e.Graphics.DrawString("made in china", fdatabd, Brushes.Black, 10, 53); 
                    if (cadaum[1].Length >= 30)
                    {
                        e.Graphics.DrawString(descr2, fdatabd, Brushes.Black, 10, 77);
                    }
                    e.Graphics.DrawString(descr3, fdatabd, Brushes.Black, 10, 87);
                    e.Graphics.DrawString("*" + cadaum[0].ToString() + "*", fbarra, Brushes.Black, 8, 105);
                  
                    // UPPER RIGHT SIDE
                     e.Graphics.DrawString("TRADEMARK", fsystem, Brushes.Black, 205, 8);
                     e.Graphics.DrawString("COMPANY'S NAME", fdatabd, Brushes.Black, 170, 30);
                     e.Graphics.DrawString("ANY OTHER INFORMATION", fdatabd, Brushes.Black, 170, 41);
                     e.Graphics.DrawString("made in china", fdatabd, Brushes.Black, 170, 53); 
                     if (cadaum[1].Length >= 30)
                      {
                         e.Graphics.DrawString(descr2, fdatabd, Brushes.Black, 170, 77);                      }
                     e.Graphics.DrawString(descr3, fdatabd, Brushes.Black, 170, 87);
                     e.Graphics.DrawString("*" + cadaum[0].ToString() + "*", fbarra, Brushes.Black, 168, 105);
                    // CUTTING REFERENCE
                 e.Graphics.DrawString("---------------------------------------------------------------------------------------------", fdatabd, Brushes.Black, 1, 147);
                    //LOWER LEFT SIDE
                      e.Graphics.DrawString(descr2, fdatabd, Brushes.Black, 10, 155);
                      e.Graphics.DrawString(descr3, fdatabd, Brushes.Black, 10, 165);
                      e.Graphics.DrawString("*" + cadaum[0].ToString() + "*", fbarra, Brushes.Black, 8, 177);
                      e.Graphics.DrawString("Price:", fdatabd, Brushes.Black, 10, 208);
                    
                     
                      e.Graphics.DrawString(cadaum[2].ToString() +"," + cents.ToString(), fdatabd, Brushes.Black, 80, 208);
                    
                      e.Graphics.DrawString("TRADEMARK", fsystem, Brushes.Black, 45, 220); 
                    // LOWER RIGHT SIDE
                     e.Graphics.DrawString(descr2, fdatabd, Brushes.Black, 170, 155);
                     e.Graphics.DrawString(descr3, fdatabd, Brushes.Black, 170, 165);
                     e.Graphics.DrawString("*" + cadaum[0].ToString() + "*", fbarra, Brushes.Black, 168, 177);
                     e.Graphics.DrawString("Price:", fdatabd, Brushes.Black, 170, 208);
                     e.Graphics.DrawString(cadaum[2].ToString() + "," + cents.ToString(), fdatabd, Brushes.Black, 240, 208);
                    e.Graphics.DrawString("TRADEMARK", fsystem, Brushes.Black, 205, 220);
                 // end modification
                    currentPrintingRowIndex += 1;
                    e.HasMorePages = allCheckedRows.Count > currentPrintingRowIndex;
              // WITH SPECIAL THANKS FOR THE USER Reza Aghaei, in order to his help in the software credits his name will be quoted
              
