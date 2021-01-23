    public class WebService
    {
        protected string jsonstring;
        // Other code
    
        // Method
    	public T stringToObject<T>(){
    		return JsonConvert.DeserializeObject<T>(this.jsonstring);
    	}
    }
