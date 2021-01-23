    // Helper object to easily serialize json data. 
    public class WishListRequest {
    	public string email;
    }
    
    public class MyMonoBehavior : MonoBehaviour {
    
        ...
    		
    	private static readonly string POSTWishlistGetURL = "...bla...";
    	public WWW Post()
    	{
    		WWWForm form = new WWWForm();
    
    		// Create the parameter object for the request
    		var request = new WishListRequest { email = "abcdd@gmail.com" };
    
    		// Convert to JSON (and to bytes)
    		string jsonData = JsonUtility.ToJson(request);
    		byte[] postData = System.Text.Encoding.ASCII.GetBytes(jsonData);
    
    		Dictionary<string, string> postHeader = form.headers;
    		if (postHeader.ContainsKey("Content-Type"))
    			postHeader["Content-Type"] = "application/json";
    		else
    			postHeader.Add("Content-Type", "application/json");
    		WWW www = new WWW(POSTWishlistGetURL, postData, postHeader);
    		StartCoroutine(WaitForRequest(www));
    		return www;
    	}
    }
