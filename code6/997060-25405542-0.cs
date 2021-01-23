    public class Client
    {
    	public Dictionary<string, Dictionary<string, string>> roaming
    	{
    		get { return this._roaming ?? (this._roaming = new Dictionary<string, Dictionary<string, string>>()); }
    		set { this._roaming = value; }
    	}
    	private Dictionary<string, Dictionary<string, string>> _roaming;
    	
    	
    	public Client()
    	{
    		this.roaming.Add("en", new Dictionary<string, string> {
    			{ "login", "login" },
    			{ "logout", "logout" },
    			{ "submit", "submit" }
    		});
    		this.roaming.Add("sp", new Dictionary<string, string> {
    			{ "login", "entrar" },
    			{ "logout", "salir" },
    			{ "submit", "presentar" }
    		});
    	}
    }
