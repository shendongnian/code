     void refreshtable()  
        {
            var query = (from x in de.HeaderTrainingAllocations
                         join y in de.MsTrainings on x.TrainingID equals y.TrainingID
                         join z in de.MsUsers on x.UserID equals z.UserID
                      select new
                         {
                             x.AllocationID,
                             x.TrainingID,
                             z.UserName,
                             x.TrainingStartDate,
                             TrainingEndDate = System.Data.Objects.EntityFunctions.AddDays(x.TrainingStartDate, ((y.TrainingDuration - 1) * 7)),
                             y.TrainingDuration,
                             x.Capacity
                         }
                         ).ToList();//get all data from tables
              foreach (var x in query)
              {
                  var cek = (from x in de.DetailTrainingAllocations
                             where x.AllocationID==x.AllocationId
                             select x).Count(); //to get amount of data in table detailTransaction
    
                  x.CurrentCapacity-=cek;//this code won't change the value of the rows in datagridview
              }
    
            dataGridView1.DataSource = query;
        }
