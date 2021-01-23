    using System.Xml.Linq;
    
    [HttpGet]
    [Route("menu")]
    public IHttpActionResult Menu(string from, string to, string callSid) 
    {
         var response = new TwilioResponse();
         response.Say("Hello World");
    
         return Ok(XElement.Parse(response.ToString()));
    }
