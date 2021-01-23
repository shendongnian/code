    ...
    for (int i = 0; i < soap.Count; i++)
    {
        Dictionary<string,object> messageData = entries[i] as Dictionary<string,object>;
        object resultData = messageData["message"];
        Dictionary<string,object> fromData = messageData["from"] as Dictionary<string, object>;
        object resultData = fromData["name"]
        Debug.Log("JSON string : " + resultData.ToString());
    }
    ...
