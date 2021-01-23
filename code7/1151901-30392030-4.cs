    StringBuilder sb = new StringBuilder();
     foreach (DataRow row in dt1.Rows)
    {
          if (DateTime.Parse(row.ItemArray[41].ToString()) == currendate)
          {
              sb.AppendLine("Expired carte for the employee" + row["EmpFName"]); 
          }
    }
    MessageBox.Show(sb.ToString());
