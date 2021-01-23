    DataManager.NotificationManager obj = new DataManager.NotificationManager();
    DataTable dt1 = obj.GetListExpiryDate();
    DateTime currendate = DateTime.Today;
    foreach(DataRow row in dt1.Rows)
    {  
        if (DateTime.Parse(row.ItemArray[41].ToString()) == currendate) 
        { 
             MessageBox.Show("Expired carte for the employee" + row["EmpFName"]); 
        }
        else 
        { 
             MessageBox.Show(" not Expired carte for the employee"+row["EmpFName"]); 
        }
    }
