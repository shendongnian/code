    public class MyPage : Page
    {
        private MyUserControl myControl;
    
        public void MyPage_Load()
        {
            myControl.OnChange += myControl_OnChange;
        }
    
        private void myControl_OnChange(object sender, ListChangedEventArgs e)
        {
            // ... do something
        }
    }
