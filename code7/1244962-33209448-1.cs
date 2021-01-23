    using System;
    
    using Xamarin.Forms;
    
    namespace LoginFormExample
    {
    	public class LoginViewFormInCS : ContentPage
    	{
    		public LoginViewFormInCS ()
    		{
    			BindingContext = new LoginViewModel();
    			Entry myEntry = new Entry ();
    			Button myButton = new Button ();
    			myButton.SetBinding (Button.CommandProperty, new Binding ("LoginCommand", 0)); 
    			Content = new StackLayout { 
    				Children = {
    					new StackLayout()
    					{
    						Children=
    						{
    							myEntry,
    							myButton
    						}
    					}
    				}
    			};
    		}
    	}
    }
