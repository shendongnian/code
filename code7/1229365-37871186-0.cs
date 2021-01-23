    [Tag("InternalUse")]
    		[OperationSummary("Does stuff.")]
    		[OperationNotes("I mean, it does some really interesting stuff. Stuff like you wouldn't believe.")]
    		[ResponseCode(400, "Four hundred error")]
    		[ResponseCode(200, "OK")]
    		[ResponseCode(205, "Some error")]
    		[ResponseCode(404, "Not found")]
    		[ResponseCode(401, "Something weird happened")]
    		[ResponseCode(301, "Three O one Something weird happened")]
    		[OperationContract]
    		[WebInvoke(UriTemplate = "/data", Method = "POST", RequestFormat = WebMessageFormat.Json,
    			BodyStyle = WebMessageBodyStyle.Bare)]
    		CompositeType GetDataUsingDataContract(CompositeType composite);
