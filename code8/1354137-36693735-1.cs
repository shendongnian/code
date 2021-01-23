    public class ViewMOdel()
    { 
           public ViewModel()
        {
    favTapped= new DelegateCommand<MainPageModel>(this.OnFavTapped)
     itemTapped= new DelegateCommand<MainPageModel>(this.OnItemTapped)
        }
    
    public async Task GetData()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 3)
                    sampleList.Add(new MainPageModel { sampleText = "Selected", isFav = true});
                else
                    sampleList.Add(new MainPageModel { sampleText = "UnSelected"+i.ToString(), isFav = null});
        }
        }
        private void OnFavTapped(MainPageModel arg)
        {
            if (arg.isFav == null) arg.isFav = true;
            else
                arg.isFav = !arg.isFav;
        }
        private void OnItemTapped(MainPageModel arg)
        {
            System.Diagnostics.Debug.WriteLine("Button Value: "+arg.sampleText);
            System.Diagnostics.Debug.WriteLine("Selected Item Value: "+selectedItem.sampleText);
        }
        }
