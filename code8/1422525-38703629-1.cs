    public class Item : INotifyPropertyChanged
    {
       private string _myText;
       private string _myImage;
       private bool _isExtraControlsVisible;
       public string MyText 
       {
           get{ return _myText; } 
           set{ _myText = value; OnPropertyChanged();} 
       }
       public string MyImage
       {
           get{ return _myImage; } 
           set{ _myImage = value; OnPropertyChanged();} 
       }
       public bool IsExtraControlsVisible
       {
           get{ return _isExtraControlsVisible; } 
           set{ _isExtraControlsVisible = value; OnPropertyChanged();} 
       }
    }
