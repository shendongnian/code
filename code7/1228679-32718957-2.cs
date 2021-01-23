    <%@ WebHandler Language="C#" Class="Handler" %>
    
    using System;
    using System.Web;
    using System.Net;
    
    public class Handler : IHttpHandler
    {
        public void ProcessRequest (HttpContext context)
        {
    	
        //retrieve your data from context.Request. Depending on how you choose to send the data from Android, the data may be in context.Request.QueryString or context.Request.Form or context.Request.Files. Commonly, data is sent back and forth as JSON or XML in the body. See my helper method below for retriving it
    
        //it's a good idea to let the client know we processed their request successfully
        context.Resonse.StatusCode = HttpStatusCode.OK;
    	context.Response.ContentType = "text/plain";
        context.Response.Write("Success"); //this line is redundant because of the status code, but I wanted to show you how to write data to the response
        }
    
        public bool IsReusable { get { return false; } }
    }
