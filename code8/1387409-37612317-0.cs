    List <ResponseObject> myresponse =JsonConvert.DeserializeObject<List<ResponseObject>>(responseFromServer);
    var DomainArray = new List<string>();
    for (int i = 0; i < myresponse.Count; i++)
    {
    for (int j = 0; j < myresponse[i].EmailAddressSuffixes.Count; j++)
    {
    DomainArray.Add( myresponse[i].EmailAddressSuffixes[j] );
    }
    }
