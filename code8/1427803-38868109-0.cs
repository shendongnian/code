    public interface IBaseViewModel
    {
        ICollection<DocumentCategory> Categories { get; set; }
    }
    
    public interface IBaseViewModel<T> : IBaseViewModel
    {
        T ViewModel {get; set;}
    }
