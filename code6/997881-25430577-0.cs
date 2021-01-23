    public interface IViewModel { }
    public class ViewModel1 : IViewModel { }
    public class ViewModel2 : IViewModel { }
    private IViewModel _viewModel1 = new ViewModel1();
    private IViewModel _viewModel2 = new ViewModel2();
    private IViewModel _CurrentPageViewModel;
    public IViewModel CurrentPageViewModel 
    {
        get { return _CurrentPageViewModel; }
        set { Set(() => CurrentPageViewModel, ref _CurrentPageViewModel, value); } 
    }
