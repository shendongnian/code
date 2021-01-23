    public interface ITearOffViewModel : IViewModel
        {
            string Title { get; }
    
            IViewModel Content { get; }
        }
