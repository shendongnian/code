        public static ServiceHost GetHost( string pServer, int pPort, Type pInterface, Type pObject, string pService, string pWSDL )
        {
            string iHTTPAddress   = "http://"    + pServer + ":" + pPort.ToString( ) + "/" + pService;
            string iMetaAddress   = "http://"    + pServer + ":" + pPort.ToString( ) + "/" + pService + "/" + pWSDL;
            string iNetTCPAddress = "net.tcp://" + pServer + "/" + pService + "/" + pWSDL;
            
            Type iInterface = pInterface;
            Type iObject    = pObject;
            ServiceHost iHost = new ServiceHost( iObject );
            
            // HTTP Binding => Create and Prepare
            Uri iHTTPUri = new Uri( iHTTPAddress );
            BasicHttpBinding iHTTPBinding = new BasicHttpBinding( );
            // HTTP Binding => Add to Host
            iHost.AddServiceEndpoint( iInterface, iHTTPBinding, iHTTPAddress );
            
            // MetaData => Create and Prepare
            Uri iMetaUri = new Uri( iMetaAddress );
            ServiceMetadataBehavior iMeta = new ServiceMetadataBehavior( );
            iMeta.HttpGetUrl = iMetaUri;
            iMeta.HttpGetEnabled = true;
            // MetaData => Add to Host
            iHost.Description.Behaviors.Add( iMeta ); 
            
            Uri iNetTCPUri = new Uri( iNetTCPAddress );
            Binding iNetTCPBinding = MetadataExchangeBindings.CreateMexTcpBinding( );
            iHost.AddServiceEndpoint( typeof( IMetadataExchange), iNetTCPBinding, iNetTCPUri );
            
            return iHost;
        }
