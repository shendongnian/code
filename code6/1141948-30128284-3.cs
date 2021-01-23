    protected T GetResponseModel<T>(Stream respStream) where T : class
            {
                if (respStream != null)
                {
                    var respStreamReader = new StreamReader(respStream);
                    Task<string> rspObj = respStreamReader.ReadToEndAsync();
                    rspObj.Wait();
                    
                    Debug.WriteLine("Response: {0}", rspObj.Result);
    
                    T jsonResponse = JsonConvert.DeserializeObject<T>(rspObj.Result);
    
                    return jsonResponse;
                }
    
                return default(T);
            }
