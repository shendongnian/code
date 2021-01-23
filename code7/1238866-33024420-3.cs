        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            foreach (var item in operationDescription.Messages[0].Body.Parts)
            {
                item.Type = typeof(string);
            }
            return base.GetRequestDispatchFormatter(operationDescription, endpoint);
        }
