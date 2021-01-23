    @functions{
    
     protected int GetReadinessAvg()
        {
            var avgReadiness = 0;
            var countItems = 0;
            foreach (var item in db.Reviews)
            {
                avgReadiness = avgReadiness + item.LecturerReadine;
                countItems++;
            }
            avgReadiness = avgReadiness / countItems;
    
            return avgReadiness;
        }
    
    }
