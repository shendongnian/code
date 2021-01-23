    System.Runtime.Remoting.RemotingException
    [] Designer process terminated unexpectedly!
       at Microsoft.Expression.DesignHost.Isolation.Primitives.ProcessDomainFactory.ProcessIsolationDomain.Microsoft.Expression.DesignHost.Isolation.IIsolationDomain.CreateInstance(String assemblyName, String assemblyCodeBase, String typeName)
       at Microsoft.Expression.DesignHost.Isolation.Primitives.IsolationBoundary.Initialize()
       at Microsoft.Expression.DesignHost.Isolation.Primitives.IsolationBoundary.CreateInstance[T](Type type)
       at Microsoft.Expression.DesignHost.Isolation.IsolatedExportProvider.Initialize()
       at Microsoft.VisualStudio.ExpressionHost.Services.VSIsolationService.CreateExportProvider(IIsolationTarget isolationTarget, ICatalogFactory catalogFactory, IExportFilter filter)
       at Microsoft.Expression.DesignHost.Isolation.IsolationService.CreateLease(IIsolationTarget isolationTarget)
       at Microsoft.Expression.DesignHost.IsolatedDesignerService.CreateLease(IIsolationTarget isolationTarget, CancellationToken cancelToken, DesignerServiceEntry& entry)
       at Microsoft.Expression.DesignHost.IsolatedDesignerService.IsolatedDesignerView.CreateDesignerViewInfo(CancellationToken cancelToken)
       at Microsoft.Expression.DesignHost.Isolation.IsolatedTaskScheduler.InvokeWithCulture[T](CultureInfo culture, Func`2 func, CancellationToken cancelToken)
       at Microsoft.Expression.DesignHost.Isolation.IsolatedTaskScheduler.<>c__DisplayClassa`1.<StartTask>b__6()
       at System.Threading.Tasks.Task`1.InnerInvoke()
       at System.Threading.Tasks.Task.Execute()
