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
            previousContent = this.Content; // save state
            NewPage abt = new NewPage();
            this.Content = abt; // set new state
        }
        //And later You can restore this state by:
        public void RestorPreviousContent()
        {
            this.Content = previousContent;
        }
