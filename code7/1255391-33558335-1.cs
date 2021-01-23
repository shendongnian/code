    class NewtonsoftJsonBehavior : WebHttpBehavior
    {
        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            return new UriTemplateDispatchFormatter(
                operationDescription,
                new NewtonsoftJsonDispatchFormatter(operationDescription, endpoint, true),
                GetQueryStringConverter(operationDescription),
                endpoint.Contract.Name,
                endpoint.Address.Uri);
        }
        protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription od, ServiceEndpoint ep)
        {
            return new NewtonsoftJsonDispatchFormatter(od, ep, false);
        }
    }
