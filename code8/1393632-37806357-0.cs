    [TestMethod]
    public void BusinessUnitTest()
    {
    	workflowContext.PrimaryEntityName = "Entity name";
    
    	WorkflowInvoker invoker = new WorkflowInvoker(new DespatchStockOrder());
    	invoker.Extensions.Add<ITracingService>(() => tracingService);
    	invoker.Extensions.Add<IWorkflowContext>(() => workflowContext);
    	invoker.Extensions.Add<IOrganizationServiceFactory>(() => factory);
    	IDictionary<string, object> outputs = invoker.Invoke();
    }
