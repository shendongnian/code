    foreach (var obj in StuList)
    {
         var rollNoRecord = db.Student_Roll_No_Assign.FirstOrDefault(a => a.Company_ID == obj.Company_Id && a.COMPANY_LOCATION_ID == obj.Company_Location_Id && a.Academic_Year_Id == obj.Academic_Year_Id && a.Class_Id == obj.Class_Id && a.Delete_Flag == false);
         if (rollNoRecord != null)
         {
               //data.RollNo = rollNoRecord.Set_Roll_No;
               obj.RollNo = rollNoRecord.Set_Roll_No;
         }
         else
         {
               //data.RollNo = string.Empty;
               obj.RollNo = string.Empty;
         }
         //StuListforRollNo.Add(data);
    }
