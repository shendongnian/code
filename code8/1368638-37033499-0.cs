    public class UserControl : BindableBase
    {
    
        private string textboxText;
        public string TextBoxText
        {
           get { return textboxText; }
           set { SetProperty(ref textboxText,value); }
        }
    
    }
