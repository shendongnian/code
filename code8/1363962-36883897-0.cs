                DataTable newDT = new DataTable();
                foreach (DataTable dt in myDt.Rows)
                {
                    //More Code
                    foreach (DataRow row in dt.Select("email IS NOT NULL"))
                    {
                        newDT.Rows.Add(row);
                    }
                }
                myDt.Merge(newDT);
