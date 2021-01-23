    public JToken Search( ObjCode objcode, object parameters, int limit = 100 )
            {
            VerifySignedIn();
            string[] p = parameterObjectToStringArray(parameters, "sessionID=" + SessionID);
            JToken json = null;	
            JToken count = null;
            count = client.DoGet(string.Format("/{0}/count", objcode),limit,p);
        	for(int i=0; i<count; i+limit){
	            if (limit > 100)
	            {
	               json = client.DoGet(string.Format("/{0}/search?$$LIMIT={1}&$$FIRST={2}", objcode,limit,i),limit,p);
	            }
	            else
	            {
	               json = client.DoGet(string.Format("/{0}/search&$$FIRST={1}", objcode,i),limit,p);
	            }
	            return json;
	        }
       	 }
