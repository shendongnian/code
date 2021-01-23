            while (rdr.Read()) {
                /* for each row */
                List<String> listOfColumns = new List<string>();
                for (int i = 0; i < rdr.FieldCount; i++) {
                    var val = rdr[i];
                    if ("1" == val) {
                        /* if the value of the column is 1, add the column name from the dictionary */
                        listOfColumns.Add(columnNames[i]);
                    }
                }
            }
 
