    config.EnableInstallers(); //ensures msmq is created
    config.PurgeOnStartup( true ); //only for self-hosted
    config.Transactions().Disable();
    config.DisableFeature<StorageDrivenPublishing>();
    Bus = NServiceBus.Bus.CreateSendOnly( config ); //create SendOnlyBus here
