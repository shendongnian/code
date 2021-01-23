    [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void GetOptions();
    public void GetOptions()
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
        }
