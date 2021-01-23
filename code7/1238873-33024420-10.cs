        public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (var operation in endpoint.Contract.Operations)
            {
                if (operation.Behaviors.Contains(typeof(MyOperationBehavior)))
                    continue;
                operation.Behaviors.Add(new MyOperationBehavior());
            }
            base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
        }
