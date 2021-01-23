		 [HttpPost]
		 public HttpResponseMessage ProcessRequest([FromBody] string sJsonRequest)
		 {
			 ResponseMsg rspMsg = null;
			 RequestMsg oRequestMsg = null;
			 string sDeteializeMsg = "";
			 try
			 {
				 string sUnescapeJsonData = System.Uri.UnescapeDataString(sJsonRequest);
				 sJsonRequest = sUnescapeJsonData;
				 oRequestMsg = (RequestMsg)JsonHelper.Deserialize(typeof(RequestMsg), sJsonRequest);
			 }
			 catch (Exception ex)
			 {
				 ...
			 }
			 if (oRequestMsg == null)
			 {
				 return AppHelper.GetUTF8PlainTextHttpResponse(@"Invalid request message.");
			 }
			 rspMsg = new ResponseMsg(oRequestMsg);
			 string sJsonRet = "";
			 try
			 {
				 if(oRequestMsg.RequestType==SavingFile)
                  {
                       byte[] bytes = System.Convert.FromBase64String(oRequestMsg.Base64Data);
                       System.IO.File.WriteAllBytes(sFileName, bytes);
                       ....
                   }
				//update rspMsg ....
			 }
			 catch (Exception ex)
			 {
				 ...
			 }
			 finally
			 {
				 sJsonRet = JsonHelper.Serialize(rspMsg);
			 }
			 return AppHelper.GetUTF8PlainTextHttpResponse(sJsonRet);
		 }
