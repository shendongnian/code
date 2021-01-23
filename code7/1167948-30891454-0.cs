            if (Convert.IsDBNull(e.Value) {
            } else {
               string stringValue = (string)e.Value;
               if ((stringValue.IndexOf("JL") > -1))
               {
                   Debug.WriteLine("The Format Value " + e.Value);
                   //format the row colour
                   row.DefaultCellStyle.ForeColor = Color.White;
                   row.DefaultCellStyle.BackColor = Color.Red;
               }
               else
               {
                  Debug.WriteLine("The Value " + e.Value);
               }
            }
