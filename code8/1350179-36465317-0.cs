    public class MainActivity : Activity, Android.Text.ITextWatcher
    	{
    		public void AfterTextChanged (Android.Text.IEditable s)
    		{
    			
    		}
    
    		public void BeforeTextChanged (Java.Lang.ICharSequence s, int start, int count, int after)
    		{
    		}
    
    		public void OnTextChanged (Java.Lang.ICharSequence s, int start, int before, int count)
    		{
    			//were text is changed
    		}
    ...
    }
