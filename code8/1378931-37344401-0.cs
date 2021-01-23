    public class MainWindowViewModel: PropertyChangedNotification{   
       public RelayCommand GenerateCommand { get; set; }
       public MainWindowViewModel( ) {
       GenerateCommand = new RelayCommand( OnGenerateClicked, CanExecuteGenerate);
       Model = new MainModel( );
       }
       private bool CanExecuteGenerate( ) {
           if( Model != null )
               return ( Model.Name != "" && Model.Title != "" ) ? true : false;
           return  false;
       }
       public void someothermethod(){
           Model.Name = "James"
           Model.Title = "Doctor"
           GenerateCommand.RaiseCanExecuteChanged();
       }
       public void OnGenerateClicked(){
           //Do some other stuff
       }
    }
