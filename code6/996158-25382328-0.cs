    private async void GetPractice()
    {
        try 
        {
            _practiceItems = await _homeService.GetPracticeList(this);
            RaisePropertyChanged(() => PracticeItems); 
        } 
        catch (Exception ex) 
        {
            //return null;
        }
    }
