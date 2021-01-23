    CountdownEvent Countdown;
    void LoadExcelData(object data)
    {
        // loads excel data to global array "Weather" which is used later on
        Countdown.Signal();
    }
    //Execute every 20 minutes  (Timer). Do not Execute in case previouse run is not finished
    void inserting(List<object> excels)
    {
        Countdown = new CountdownEvent(excels.Count); 
        int i = 0;
        while (i < excels.Count) {
            ThreadPool.QueueUserWorkItem(LoadExcelData, excels[i++].File_name);
        }
        Countdown.Wait();
        InsertToDB(WeatherList); //insert data which was read from Excels
        isRunning = false; //Data was successefully inserted to DB 
    }
