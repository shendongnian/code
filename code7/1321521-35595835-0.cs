    DateTime startDateTime = DateTime.Now;
    using (var client = new HttpClient)
    {
        DateTime currentDateTime = DateTime.Now;
        while(currentDateTime - startDateTime < threshold)
        {
            currentDateTime = DateTime.Now;
            if(dataArrive)
            {
               startDateTime = DateTime.Now;
            }
        }
        
        //TO DO: Close communication channel
    }
