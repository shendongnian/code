        ...
        Exception ex = null;
        try
        {
        	Infos infos = await WebServices.GetInfos(url, parameters, "");
        	return infosCe;
        }
     
        // Exceptions
        catch (Exception e)
        {
        	ex = e;
        }
		if (ex != null)
		{
			if (ex is DeserializeException)
			{
				DeserializeException dE = (DeserializeException)ex;
				ExceptionsMsgboxHelper.MsgboxDeserialize(dE);
			}
			if (ex is NoInternetAccessException)
			{
				NoInternetAccessException niaE = (NoInternetAccessException)ex;
				ExceptionsMsgboxHelper.MsgboxNoInternetAccess(niaE);
			}
			if (ex is NoJSONException)
			{
				NoJSONException njsonE = (NoJSONException)ex;
				ExceptionsMsgboxHelper.MsgboxNoJSON(njsonE);
			}
			...
		}
        return null;
