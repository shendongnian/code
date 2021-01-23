            try
            {
                reader = myDECommand.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if(reader["Column1"].ToString() == "") {
                            //does nothing if the current line is "bugged" (containing no values at all, typically happens after reboot of 3rd party equipment).
                        }
                        else {
                            //grab relevant tag data and set the csv line for the current row.
                            string csvDetails = reader["Column1"] + "," + reader["Column2"] + "," + String.Format("{0:0.0}", reader["Column3"]) + "," + String.Format("{0:0.000}", reader["Column4"]) + "," + reader["Column5"];
                            using (FileStream fsWDT = new FileStream(newFileName, FileMode.Append, FileAccess.Write))
                            using(StreamWriter swDT = new StreamWriter(fsWDT))
                            {
                                //write csv line to file.
                                swDT.WriteLine(csvDetails.ToString());
                            }
                        }
                    }
                }
            }
