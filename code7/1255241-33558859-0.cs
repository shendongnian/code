    public class MainViewModel : ViewModelBase
    {
            public enum ViewModelState
            {
                Default,
                Details
            }
    
            private ViewModelState currentState;
            public ViewModelState CurrentState
            {
                get { return currentState; }
                set
                {
                    this.Set(ref currentState, value);
                    OnCurrentStateChanged(value);
                }
            }
    
            public RelayCommand GotoDetailsStateCommand { get; set; }
            public RelayCommand GotoDefaultStateCommand { get; set; }
    
            public MainViewModel()
            {
                GotoDetailsStateCommand = new RelayCommand(() =>
                {
                    CurrentState = ViewModelState.Details;
                });
    
                GotoDefaultStateCommand = new RelayCommand(() =>
                {
                    CurrentState = ViewModelState.Default;
                });
            }
    
            public void OnCurrentStateChanged(ViewModelState e)
            {
                Debug.WriteLine("CurrentStateChanged: " + e.ToString());
            }
    }
