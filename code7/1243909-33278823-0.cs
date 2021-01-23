    WebRequest wc = HttpWebRequest.Create(uri);
    try {
       using (HttpWebResponse response = await wc.GetResponseAsync() as HttpWebResponse){
          DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BingMapsRESTService.Common.JSON.Response));
          return ser.ReadObject(response.GetResponseStream()) as BingMapsRESTService.Common.JSON.Response;
       }
    }
    catch(Exception ex){
       return null;
    }
