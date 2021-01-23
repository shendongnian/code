    public void LoadData(){
        while(Main.IsProcessRunning){
            var emails = new dummyRepositories().GetAllEmails(); //This will return List<Emails>.
            SendDataParallel(emails).Wait();
        }
    }
