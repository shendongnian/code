    ContainerBuilder builder = new ContainerBuilder();
    
    builder.RegisterType<IntroDialog>()
      .As<IDialog<object>>()
      .InstancePerDependency();
    
    builder.RegisterType<JobsMapper>()
    	.Keyed<IMapper<DocumentSearchResult, GenericSearchResult>>(FiberModule.Key_DoNotSerialize)
    	.AsImplementedInterfaces()
    	.SingleInstance();
    
    builder.RegisterType<AzureSearchClient>()
    	.Keyed<ISearchClient>(FiberModule.Key_DoNotSerialize)
    	.AsImplementedInterfaces()
    	.SingleInstance();
    
    builder.Update(Conversation.Container);
