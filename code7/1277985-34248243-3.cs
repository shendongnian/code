    using System;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Threading;
    namespace DemoGenericHandler
    {
    	public class MyHandler : System.Web.IHttpHandler
    	{
    		
    		public virtual bool IsReusable {
    			get {
    				return false;
    			}
    		}
    		
    		public virtual void ProcessRequest (HttpContext context)
    		{
    			//if you need get the value sent from client (ajax-post)
    			//string valueSendByClient = context.Request.Form["data"] ?? string.Empty;
    			//you must use a library like JSON.NET (newtonsoft) to serialize an object
    			//here for simplicity i'll build the json object in a string variable:
    			string jsonObj = "{\"Value1\": \"1\",\"Value2\":  \"2\",\"Value3\": \"3\"}";
    			//await 5 seconds: (imitates the time that your wcf services take)
    			Thread.Sleep(5000);
    			//send the result to the client
    			context.Response.ContentType = "text/json";
    			context.Response.Write(jsonObj);
    		}
    	}
    }
