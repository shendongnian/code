        public void updateDSField<T>(string fieldName, T newVal)
        {   
            // updates field in dataset
            var col = TheDataTable.Columns[fieldName];
            foreach (DataRow row in TheDataTable.Rows) row[col] = newVal; // * this marks the rows to be update by the commandtext
            // create adapter and update string
            TheAdapter.UpdateCommand = TheConn.CreateCommand();
            string newValString = newVal.ToString();
            if (typeof(T) == typeof(string)) newValString = "'" + newValString + "'";
            TheAdapter.UpdateCommand.CommandText = "UPDATE [" + TheTableName + "] SET [" + fieldName + "] =" + newValString;
            TheAdapter.Update(TheDS);  // this will only update those rows marked by step * above
        } 
