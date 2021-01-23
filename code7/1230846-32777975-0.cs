    public class C
    {
        public C()
        {
            _counter = 0; // initialize the counter when creating a class instance
        {
        private int _counter;
        private void Handler()
        {
            if ($System.Users.Login($Tag_InputUsername, $Tag_InputPassword))  
            {
                $Pages.MainPage.PasswordBox.Password = ""; //Resets the passwordbox password at login
                $HMI.ShowPage("LidSettings"); //Opens the Lidsettings page
                $Pages.LidSettings.Slider2.Value = 0; //Disables the advanced settings option
                
                _counter++; // increment the counter field
            }
            else
            {  
                $Pages.MainPage.PasswordBox.Password = ""; //resets password
            }
        }
    }
