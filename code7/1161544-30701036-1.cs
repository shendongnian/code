    public string PostSampleMethod(Stream data)
     {
        // convert Stream Data to StreamReader
        StreamReader reader = new StreamReader(data);
        // Read StreamReader data as string
        string xmlString = reader.ReadToEnd();
        string returnValue = xmlString;
        // return the XMLString data
        return returnValue;
        }
        public string GetSampleMethod(string strUserName)
    {
        StringBuilder strReturnValue = new StringBuilder();
        // return username prefixed as shown below
        strReturnValue.Append(string.Format
		(”You have entered userName as {0}”, strUserName));
        return strReturnValue.ToString();
        }
