    using System;
    
    using Xamarin.Forms;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Diagnostics;
    
    namespace pcl
    {
    	public class mainPage : ContentPage
    	{
    		public mainPage ()
    		{
    	
    			superSimpleGetRequest ();
    
    
    			Content = new StackLayout { 
    				Children = {
    					new Label { Text = "Hello StackOverflow" }
    				}
    			};
    		}
    
    		async void superSimpleGetRequest(){
    			var url = "http://ohiovr.com/church_files/dayspringWesleyan/mainscreen.xml";
    			var myXMLstring = await AccessTheWebAsync(url);
    			Debug.WriteLine (myXMLstring);
    		}
    
    		async Task<String> AccessTheWebAsync(String url)
    		{ 
    			// You need to add a reference to System.Net.Http to declare client.
    			HttpClient client = new HttpClient();
    
    			// GetStringAsync returns a Task<string>. That means that when you await the 
    			// task you'll get a string (urlContents).
    			Task<string> getStringTask = client.GetStringAsync(url);
    
    			// You can do work here that doesn't rely on the string from GetStringAsync.
    			//DoIndependentWork();
    
    			// The await operator suspends AccessTheWebAsync. 
    			//  - AccessTheWebAsync can't continue until getStringTask is complete. 
    			//  - Meanwhile, control returns to the caller of AccessTheWebAsync. 
    			//  - Control resumes here when getStringTask is complete.  
    			//  - The await operator then retrieves the string result from getStringTask. 
    			string urlContents = await getStringTask;
    
    			// The return statement specifies an integer result. 
    			// Any methods that are awaiting AccessTheWebAsync retrieve the length value. 
    			return urlContents;
    		}
    
    
    	}
    }
