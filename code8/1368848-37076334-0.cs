    [WebInvoke(Method = "POST",
                        ResponseFormat = WebMessageFormat.Json,
                        BodyStyle = WebMessageBodyStyle.WrappedRequest,
                        RequestFormat = WebMessageFormat.Json
                       )]
            [OperationContract]
            public TestData GetData(string value)
            {
                TestData tsd = TestData.GetTestData(value);  
                
                return tsd ;
            }
