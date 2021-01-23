    public class MainWindowViewModel
    {
       publicMainWindowViewModel
       {
           LoadData();
       }
       private void LoadData()
       {
          _clipsFound=new ObservableCollection<Clip>();
          for(int startIndex=0; startIndex<10; startIndex++)
          {
              collection.Add(new Clip(){ID=startIndex, Name="Bob", Duration=startIndex++});
          }
       }
      
       public ObservableCollection<Clip> _clipsFound;
       public ObservableCollection<Clip> collection
         {
             get
             {
                 return _clipsFound;
             }
             set
             {
                 _clipsFound = value;      
             }
         }
    }
