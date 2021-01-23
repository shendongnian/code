    using System.ComponentModel;
        namespace Overlay.ViewModels
        {    
         public class CanvasOverlayViewModel : INotifyPropertyChanged
         {
           private int exemple;
           public int Exemple
           {
             get 
             {
                return exemple;
             }
             set
             {
               exemple = value;
               OnPropertyChanged(nameof(Exemple));  // IMPORTANT
             }
           } 
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => 
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
