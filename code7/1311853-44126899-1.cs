        [assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
        namespace Your.Namespace
        {
        	public class MessageAndroid : IMessage
        	{
        		public void LongAlert(string message)
        		{
        			Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        		}
        
        		public void ShortAlert(string message)
        		{
        			Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        		}
        	}
        }
