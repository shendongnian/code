    public void Encode()
    {
        upperEncodedMsg = new StringBuilder();
        string message = Convert.ToString(messageTxt.Text);
        char[] encodeArray = message.ToUpper().ToCharArray();
        for(int i = 0; i < encodeArray.Length; i++)
        {
            //Use the mappings created earlier to get the associated char.
            char outputLetter;
            charMapping.TryGetValue(encodeArray[i], out outputLetter);
            //Append letter to your upperEncodedMsg StringBuilder.          
            upperEncodedMsg.Append(outputLetter);
        }
    }
