          public class Login
            {
        
                public static event Action<string> TextChange;
                private static void OnTextChange(string newText)
                {
                    if (TextChange != null)
                        TextChange(newText);
                }
                public static void  UserLogin(string driver, string userName,string password)
                {
                    OnTextChange(userName);
                }
            }
            public class Form1
            {
        
                private void registerLoginEvent()
                {
                    Login.TextChange += Login_TextChange;
                }
                private void Login_TextChange(string newText)
                {
                    this.BeginInvoke(()=>label.text = newText);
                }
            }
