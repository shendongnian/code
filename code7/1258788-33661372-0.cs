    MySqlDataReader LECTOR = cmd.ExecuteReader();
                    bool flag = true;
                    while (LECTOR.Read()) {
                        if (flag) { //first time it creates the columns
                            for (int i = 0; i < LECTOR.FieldCount; i++)
                            {
                                //creates the columns
                                RS.Columns.Add(LECTOR.GetName(i));
                                //Change the column (in this case I can use a conditional statement to be more specific and accurate about the data type)
                                RS.Columns[LECTOR.GetName(i)].DataType = typeof(string);
                            }
                            flag = !flag; // to mark that tthe column creation is done
                        }
                        //create a data row out of the scope
                        DataRow FILA = RS.NewRow();
                        for (int i = 0; i < LECTOR.FieldCount; i++)
                        {
                            //Put the data into the row, using the key (GetName)
                            FILA[LECTOR.GetName(i)] = LECTOR.GetValue(i).ToString();
                            //checks if it is the last case (I dont know why it didn't work if I wrote it after the for)
                            if (i + 1 == LECTOR.FieldCount) { RS.Rows.Add(FILA); }
                        }   
                    }
