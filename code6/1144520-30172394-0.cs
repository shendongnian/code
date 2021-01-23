    public void SaveResponse(IForm form, bool isLive, HttpRequestBase request)
    {
        try
        {
            var response = new FormBrokerResponses();
            // Initialize some vars on response
    
            using (var memory = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(FormKeyValue[]));
                serializer.WriteObject(memory, request.Form.AllKeys.Select(r => new FormKeyValue(r, request.Form[r])).ToArray());
                memory.Flush();
                memory.Seek(0, SeekOrigin.Begin);
                response.Values = Encoding.UTF8.GetString(memory.ToArray());
            }
    
            _dataHandler.SaveFormBrokerResponses(response);
        }
        catch (Exception ex)
        {
            throw new Exception("boom explosions");
        }
    
        Dispatch(form,isLive,request);
    }
    virtual void Dispatch(IForm form, bool isLive, HttpRequestBase request){
        Task.Factory.StartNew(() => DispatchFormResponseViaEmail(form, isLive, request.Form.AllKeys.ToDictionary(r => r, r => (object)request.Form[r])));
    }
