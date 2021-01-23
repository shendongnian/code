     foreach(DataRow row in results.Rows)
            {
                credit = Convert.ToBoolean(row["Credits"].ToString());
                if(credit)
                {
                    if (String.IsNullOrWhiteSpace(selectString))
                    {
                        tempString = row["Ord_Inv_No"].ToString();
                        selectString = String.Format("'{0}', '{0}C'",tempString);
                    }
                    else
                    {
                        tempString = row["Ord_Inv_No"].ToString();
                        selectString += String.Format(", '{0}', '{0}C'", tempString);
                    }
                    
                }
            }
            // The following three lines are for troubleshooting, shows the items being selected out and the initial count.
            // If DriverKey is 9 and dates are 5-2-16 - 5-8-16 String should show to INV numbers and count should be 19
            if (!String.IsNullOrWhiteSpace(selectString))
                MessageBox.Show(selectString);
            MessageBox.Show(results.Rows.Count.ToString());
            // only process if string is not empty, need code
            if (!String.IsNullOrWhiteSpace(selectString))
            {
                try
                {
                    var rows = results.Select("Ord_Inv_No IN (" + selectString + ")");
                    foreach (var row in rows)
                        row.Delete();
                    results.AcceptChanges();
                    // This is for troubleshooting, gets the final number of rows after edits 
                    // If DriverKey is 9 and dates are 5-2-16 - 5-8-16 final count should be 17
                    MessageBox.Show(results.Rows.Count.ToString());
                    results.Columns.Remove("Credits");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
