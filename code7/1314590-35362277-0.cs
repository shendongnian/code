    SqlDataReader dataReader = null;
    using (dataReader = cmd.ExecuteReader())
    {
          DataTable dtData = new DataTable(storedProcedureName);
          //CollectionBase ma GetEnumerator
          object[] values = new object[dr.FieldCount];
          Type[] columnTypes = new Type[dr.FieldCount];
          for (int i = 0; i < dr.FieldCount; i++)
          {
            Type columnType = dr.GetFieldType(i);
            string columnName = dr.GetName(i);
            if (columnType != null)
            {
              dtData.Columns.Add(columnName, columnType);
              columnTypes[i] = columnType;
            }
          }
          t1 = DateTime.Now.Subtract(d1);
          while (dr.Read())
          {
            int columnsRead = dr.GetValues(values);
            DataRow newRow = dtData.NewRow();
            for (int i = 0; i < dtData.Columns.Count; i++)
            {
              if (columnTypes[i].Name == "Int32") newRow[i] = values[i] != null && values[i] != DBNull.Value ? Convert.ToInt32(values[i]) : Base.BussinesLayer.Utils.Int32NullValue;
              else if (columnTypes[i].Name == "Int16") newRow[i] = values[i] != null && values[i] != DBNull.Value ? Convert.ToInt16(values[i]) : Base.BussinesLayer.Utils.Int16NullValue;
              else if (columnTypes[i].Name == "String") newRow[i] = values[i] != null && values[i] != DBNull.Value ? Convert.ToString(values[i]) : Base.BussinesLayer.Utils.StringNullValue;
              else if (columnTypes[i].Name == "Decimal") newRow[i] = values[i] != null && values[i] != DBNull.Value ? Convert.ToDecimal(values[i]) : Base.BussinesLayer.Utils.DecimalNullValue;
              else if (columnTypes[i].Name == "DateTime") newRow[i] = values[i] != null && values[i] != DBNull.Value ? Convert.ToDateTime(values[i]) : Base.BussinesLayer.Utils.DateTimeNullValue;
              else if (columnTypes[i].Name == "TimeSpan") newRow[i] = values[i] != null && values[i] != DBNull.Value ? EvotechUtils.ConvertToTimeSpan(values[i]) : Base.BussinesLayer.Utils.DateTimeNullValue.TimeOfDay;
              else if (columnTypes[i].Name == "Int64") newRow[i] = values[i] != null && values[i] != DBNull.Value ? Convert.ToInt64(values[i]) : Base.BussinesLayer.Utils.Int64NullValue;
              else if (columnTypes[i].Name == "Float") newRow[i] = values[i] != null && values[i] != DBNull.Value ? Convert.ToInt64(values[i]) : Base.BussinesLayer.Utils.FloatNullValue;
              else if (columnTypes[i].Name == "Double") newRow[i] = values[i] != null && values[i] != DBNull.Value ? Convert.ToInt64(values[i]) : Base.BussinesLayer.Utils.DoubleNullValue;
              else if (columnTypes[i].Name == "Byte") newRow[i] = values[i] != null && values[i] != DBNull.Value ? Convert.ToInt64(values[i]) : Base.BussinesLayer.Utils.ByteNullValue;
              else newRow[i] = DBNull.Value;
            }
            dtData.Rows.Add(newRow);
          }
          dr.Close();                                   
    }
