    Autofac.Core.DependencyResolutionException was unhandled
      _HResult=-2146233088
      _message=An exception was thrown while executing a resolve operation. See the InnerException for details.
      HResult=-2146233088
      IsTransient=false
      Message=An exception was thrown while executing a resolve operation. See the InnerException for details. ---> Operation is not valid due to the current state of the object. (See inner exception for details.)
      Source=Autofac
      StackTrace:
           at Autofac.Core.Resolving.ResolveOperation.Execute(IComponentRegistration registration, IEnumerable`1 parameters)
           at Autofac.Core.Lifetime.LifetimeScope.ResolveComponent(IComponentRegistration registration, IEnumerable`1 parameters)
           at Autofac.ResolutionExtensions.TryResolveService(IComponentContext context, Service service, IEnumerable`1 parameters, Object& instance)
           at Autofac.ResolutionExtensions.ResolveService(IComponentContext context, Service service, IEnumerable`1 parameters)
           at Autofac.ResolutionExtensions.Resolve(IComponentContext context, Type serviceType, IEnumerable`1 parameters)
           at Autofac.ResolutionExtensions.Resolve[TService](IComponentContext context, IEnumerable`1 parameters)
           at Autofac.ResolutionExtensions.Resolve[TService](IComponentContext context)
           at SingletonRepro.SampleComponent.Initialize() in e:\dev\spike\SingletonRepro\SingletonRepro\Program.cs:line 120
           at SingletonRepro.Environment.Initialize() in e:\dev\spike\SingletonRepro\SingletonRepro\Program.cs:line 75
           at SingletonRepro.Program.<Main>b__0(IActivatingEventArgs`1 e) in e:\dev\spike\SingletonRepro\SingletonRepro\Program.cs:line 17
           at Autofac.Builder.RegistrationBuilder`3.<>c__DisplayClass6.<OnActivating>b__5(Object s, ActivatingEventArgs`1 e)
           at Autofac.Core.Registration.ComponentRegistration.RaiseActivating(IComponentContext context, IEnumerable`1 parameters, Object& instance)
           at Autofac.Core.Resolving.InstanceLookup.Activate(IEnumerable`1 parameters)
           at Autofac.Core.Resolving.InstanceLookup.<Execute>b__0()
           at Autofac.Core.Lifetime.LifetimeScope.GetOrCreateAndShare(Guid id, Func`1 creator)
           at Autofac.Core.Resolving.InstanceLookup.Execute()
           at Autofac.Core.Resolving.ResolveOperation.GetOrCreateInstance(ISharingLifetimeScope currentOperationScope, IComponentRegistration registration, IEnumerable`1 parameters)
           at Autofac.Core.Resolving.InstanceLookup.ResolveComponent(IComponentRegistration registration, IEnumerable`1 parameters)
           at Autofac.Core.Activators.Reflection.AutowiringParameter.<>c__DisplayClass2.<CanSupplyValue>b__0()
           at Autofac.Core.Activators.Reflection.ConstructorParameterBinding.Instantiate()
           at Autofac.Core.Activators.Reflection.ReflectionActivator.ActivateInstance(IComponentContext context, IEnumerable`1 parameters)
           at Autofac.Core.Resolving.InstanceLookup.Activate(IEnumerable`1 parameters)
           at Autofac.Core.Resolving.InstanceLookup.Execute()
           at Autofac.Core.Resolving.ResolveOperation.GetOrCreateInstance(ISharingLifetimeScope currentOperationScope, IComponentRegistration registration, IEnumerable`1 parameters)
           at Autofac.Core.Resolving.ResolveOperation.ResolveComponent(IComponentRegistration registration, IEnumerable`1 parameters)
           at Autofac.Core.Resolving.ResolveOperation.Execute(IComponentRegistration registration, IEnumerable`1 parameters)
           at Autofac.Core.Lifetime.LifetimeScope.ResolveComponent(IComponentRegistration registration, IEnumerable`1 parameters)
           at Autofac.ResolutionExtensions.TryResolveService(IComponentContext context, Service service, IEnumerable`1 parameters, Object& instance)
           at Autofac.ResolutionExtensions.ResolveService(IComponentContext context, Service service, IEnumerable`1 parameters)
           at Autofac.ResolutionExtensions.Resolve(IComponentContext context, Type serviceType, IEnumerable`1 parameters)
           at Autofac.ResolutionExtensions.Resolve[TService](IComponentContext context, IEnumerable`1 parameters)
           at Autofac.ResolutionExtensions.Resolve[TService](IComponentContext context)
           at SingletonRepro.Program.Main(String[] args) in e:\dev\spike\SingletonRepro\SingletonRepro\Program.cs:line 38
           at System.AppDomain._nExecuteAssembly(RuntimeAssembly assembly, String[] args)
           at System.AppDomain.ExecuteAssembly(String assemblyFile, Evidence assemblySecurity, String[] args)
           at Microsoft.VisualStudio.HostingProcess.HostProc.RunUsersAssembly()
           at System.Threading.ThreadHelper.ThreadStart_Context(Object state)
           at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
           at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
           at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
           at System.Threading.ThreadHelper.ThreadStart()
      InnerException: System.InvalidOperationException
           _HResult=-2146233079
           _message=Operation is not valid due to the current state of the object.
           HResult=-2146233079
           IsTransient=false
           Message=Operation is not valid due to the current state of the object.
           Source=SingletonRepro
           StackTrace:
                at SingletonRepro.Environment.Initialize() in e:\dev\spike\SingletonRepro\SingletonRepro\Program.cs:line 68
                at SingletonRepro.Program.<Main>b__0(IActivatingEventArgs`1 e) in e:\dev\spike\SingletonRepro\SingletonRepro\Program.cs:line 17
                at Autofac.Builder.RegistrationBuilder`3.<>c__DisplayClass6.<OnActivating>b__5(Object s, ActivatingEventArgs`1 e)
                at Autofac.Core.Registration.ComponentRegistration.RaiseActivating(IComponentContext context, IEnumerable`1 parameters, Object& instance)
                at Autofac.Core.Resolving.InstanceLookup.Activate(IEnumerable`1 parameters)
                at Autofac.Core.Resolving.InstanceLookup.<Execute>b__0()
                at Autofac.Core.Lifetime.LifetimeScope.GetOrCreateAndShare(Guid id, Func`1 creator)
                at Autofac.Core.Resolving.InstanceLookup.Execute()
                at Autofac.Core.Resolving.ResolveOperation.GetOrCreateInstance(ISharingLifetimeScope currentOperationScope, IComponentRegistration registration, IEnumerable`1 parameters)
                at Autofac.Core.Resolving.InstanceLookup.ResolveComponent(IComponentRegistration registration, IEnumerable`1 parameters)
                at Autofac.Core.Activators.Reflection.AutowiringParameter.<>c__DisplayClass2.<CanSupplyValue>b__0()
                at Autofac.Core.Activators.Reflection.ConstructorParameterBinding.Instantiate()
                at Autofac.Core.Activators.Reflection.ReflectionActivator.ActivateInstance(IComponentContext context, IEnumerable`1 parameters)
                at Autofac.Core.Resolving.InstanceLookup.Activate(IEnumerable`1 parameters)
                at Autofac.Core.Resolving.InstanceLookup.<Execute>b__0()
                at Autofac.Core.Lifetime.LifetimeScope.GetOrCreateAndShare(Guid id, Func`1 creator)
                at Autofac.Core.Resolving.InstanceLookup.Execute()
                at Autofac.Core.Resolving.ResolveOperation.GetOrCreateInstance(ISharingLifetimeScope currentOperationScope, IComponentRegistration registration, IEnumerable`1 parameters)
                at Autofac.Core.Resolving.ResolveOperation.ResolveComponent(IComponentRegistration registration, IEnumerable`1 parameters)
                at Autofac.Core.Resolving.ResolveOperation.Execute(IComponentRegistration registration, IEnumerable`1 parameters)
           InnerException: ...
