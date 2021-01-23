    public abstract class BaseViewModel
    {
        public void Dispose() {} // or abstract method
    }
    public abstract class BaseViewModel<T> : BaseViewModel 
        where T : BasePoco, new()
    {
        // ViewModel stuff...
    }
    var baseViewModel = currentView.DataContext as BaseViewModel;
    if (baseViewModel != null)
        baseViewModel.Dispose();
