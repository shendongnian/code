                DataSet ExcelDataset = DBcom.GetDataset();
                //add logic for getting excel imported data in dataset format.
                string[] columnsNames = new string[100]; int loop = 0;
    
                //Comparing the Imported Excel Column With Database Table Column
                foreach (DataColumn column in ExcelDataset.Tables[0].Columns)
                {
                    string clnameExcel = column.ColumnName;                
                    int Exist = 0;
                    foreach (DataTable table in DataBaseDataset.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            string ColnamesDB = dr["DBColumn"].ToString();//DBColumn is the name of database table column name
                            
    
                            if (CompclnameExcel == CompColnamesDB)
                            {
                                Exist = 1;
                                break;
                            }
                            
                        }
                    }
                    if (Exist == 0)
                    {                    
                        columnsNames[loop] = clnameExcel;
                        loop++;
                    }
                }
                //Deleting Imported Excel Columns which is not there in Database
                foreach (string cNames in columnsNames)
                {
                    if (!string.IsNullOrEmpty(cNames))
                    {
                        ExcelDataset.Tables[0].Columns.Remove(cNames);
                    }
                }
