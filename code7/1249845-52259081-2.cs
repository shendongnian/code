    [HttpPost]
		public ActionResult AjaxRequest(int nPostType = -1, string sJsonObject = "")
		{
			  try
			  {
				  WebModelAjaxRequestTypes nReqType = (WebModelAjaxRequestTypes)nPostType;
				  bool bIsBase64Data = IsBase64Request(nReqType);
				  string sJsonRet = "";
				  if (!bIsBase64Data)
				  {
					  ....
				  }
				  else
				  {
					  //base64 content requests
					  string sBase64Data = sJsonObject;
					  //put the string into a json request and send it to api call. and get the return => sJsonRet
    				  }
				  return Content(sJsonRet);			  }
			  catch (Exception ex)
			  {
				 ....
			  }
		  }
