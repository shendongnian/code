    public interface IImageSourceViewModel<T> : INotifyPropertyChanged where T : ILine
    {
    /// <summary>
    /// Gets or sets the lines view model.
    /// </summary>
    IObservableCollection<T> LinesViewModel { get; set; }
    }
    public class ImageSourceViewModel : IImageSourceViewModel<LineViewModel>
    {
      public IObservableCollection<LineViewModel> LinesViewModel { get; set; }
    }
