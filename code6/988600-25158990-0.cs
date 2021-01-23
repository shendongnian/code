     public interface IImageSourceViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the lines view model.
        /// </summary>
        IObservableCollection<LineViewModel > LinesViewModel { get; set; }
    
     }
