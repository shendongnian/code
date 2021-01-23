    if (model != null && ModelState.IsValid)
    {
        int sIdRage = 1;
        int Interval =15;
        int previousNumber =1;
        //SequenceId will be 1,2,4,6,7,9,12,16 etc...
        // First Loop sIdRage = 1
        foreach (var list in model)
        {
            int sId = list.SequenceId;
            int nextNumber = (sId - previousNumber);
            //For the third loop nextNumber = 4 and previousNumbe = 2
            // sIdRage = nextNumber - previousNumbe
            // sIdRage = 2
            sIdRage += (sId - previousNumber);           
            count += TimeSpan.FromMinutes(Interval * sIdRage);
            list.FromTime = count.ToString();
            //Note... you need to add a faile to which you are saving the list
            //EG db.Customers.Entry(list) where Customers would be the table
            //in which you would save
            db.Entry(list).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
