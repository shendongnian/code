            foreach (DataTable table in resultTables) {
                foreach (DataRow row in table.Rows) {
                    foreach (DataColumn col in table.Columns) {
                        if (col.DataType == typeof (DateTime)) {
                            row[col] = // do something
                        }
                    }
                }
            }
