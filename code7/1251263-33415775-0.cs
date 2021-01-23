    public partial class MainWindow()
    {
        FrameworkElement previousContent; // I believe Content property is of FrameworkElement type
        public MainWindow()
        {
            ...
        }
        ...
    
        public void ChangeContent()
        {
            previousContent = this.Conent; // save state
            NewPage abt = new NewPage();
            this.Content = abt; // set new state
        }
