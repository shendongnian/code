        public static void Register(HttpConfiguration config){
            public static void Register(HttpConfiguration config)
            {
                // you config and routes here                
                
                config.MessageHandlers.Add(new ApiGatewayHandler());
        
                //....
            }
        }
