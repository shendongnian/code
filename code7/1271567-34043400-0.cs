    private string ToQueryString(NameValueCollection queryData)
	{
		var array = (from key in queryData.AllKeys
			from value in queryData.GetValues(key)
			select string.Format(CultureInfo.InvariantCulture, "{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
			.ToArray();
		return "?" + string.Join("&", array);
	}
