    //ToDo: You would have to make this ThreadSafe
    public static class Helper
    {
    	public static Dictionary<string,ClientDto> ClientDtos 
    	= new Dictionary<string, ClientDto>();
    }
    
    public class ClientDto
    {
    	public int ClientKey { get; set; }
    	public string Key { get; set; }
    	public DateTime CreatedOn { get; set; }
    }
    
    in your Global.asax add.
    protected void Application_EndRequest()
    {
    	Helper.ClientDtos.Remove(SeesionId);
    }
    
    //if this is called twice by the same client and the request is 
    //not finished processing the first request the second one will go into    
    //RequestBeingHandled and just return preventing the code from preforming 
    //the same action until the first/current is complete.
    public IHttpActionResult Ping([FromUri]int? id = null, [FromUri]string key = null)
    {
    	if(RequestBeingHandled(id, key))
    	{
    		//
    		Return .....
    	}
    	else 
    	{
    		//if not add 
    		ClientDto client = new ClientDto();
    		client.ClientKey = id;
    		client.Key = key;
    		client.CreatedOn = DateTime.Now;
    		Helper.ClientDtos.Add(SeesionId, client);
    	}
        //call some code to do stuff...
    }
    
    private bool RequestBeingHandled(int id, string key)
    {
    	//ToDo: write this code.
    	//check if its already in the dic
    	return bool;
    }
