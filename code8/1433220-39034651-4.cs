    public void Encode()
    {
        string message = Convert.ToString(messageTxt.Text);
        char[] encodeArray = message.ToUpper().ToCharArray();
        for(int i = 0; i < encodeArray.Length; i++)
        {
            //Use the mappings created earlier to get the associated char.
            char outputLetter;
            charMapping.TryGetValue(encodeArray[i], out outputLetter);
            //Check if outputLetter now contains a value and if so append it to your upperEncodedMsg StringBuilder.
            if(outputLetter != null)
            {
                upperEncodedMsg.Append(outputLetter);
            }
        }
    }
