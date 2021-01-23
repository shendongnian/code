    public class DecodeJWT: ActionFilterAttribute 
    {
    
    	public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext) 
        {
    		string firebaseAuthToken = string.Empty;
    		if (actionContext.Request.Headers.Authorization != null) {
    			firebaseAuthToken = actionContext.Request.Headers.Authorization.Scheme;
    		} else {
    			throw new HttpException((int) HttpStatusCode.Unauthorized, "Unauthorized");
    		}
    
    		string secretKey = WebConfigurationManager.AppSettings["FirebaseSecret"];
    		try {
    			string jsonPayload = JWT.JsonWebToken.Decode(firebaseAuthToken, secretKey);
    			DecodedToken decodedToken = JsonConvert.DeserializeObject < DecodedToken > (jsonPayload);
    			// TODO: Check expiry of decoded token
    		} catch (JWT.SignatureVerificationException jwtEx) {
    			throw new HttpException((int) HttpStatusCode.Unauthorized, "Unauthorized");
    		} catch (Exception ex) {
    			throw new HttpException((int) HttpStatusCode.Unauthorized, "Unauthorized");
    		}
    
    		base.OnActionExecuting(actionContext);
    	}
    
    }
