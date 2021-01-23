     public List<tempTable> GetAttendanceLeaveReportForChart(double totalWorkingdays, double attendanceDays, double leaveData, double absentData) 
     { 
         List<tempTable> temp = new List<tempTable>();
   
         tempTable obj = new tempTable();          
         obj.FieldName = "Total working days";
         obj.FieldValue = Convert.ToDouble(totalWorkingdays);
         temp.Add(obj);        
       
         obj = new tempTable(); 
         obj.FieldName = "Attendance"; 
         obj.FieldValue = Convert.ToDouble(attendanceDays); 
         temp.Add(obj); 
        
         obj = new tempTable();
         obj.FieldName = "Leave"; 
         obj.FieldValue = Convert.ToDouble(leaveData); 
         temp.Add(obj);    
        
         obj = new tempTable();
         obj.FieldName = "Absent";
         obj.FieldValue = Convert.ToDouble(absentData); 
         temp.Add(obj);        
        
         return temp;
    }
