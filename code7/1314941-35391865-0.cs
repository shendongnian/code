        public static object GetOrCreateClient()
        {
            // If there is already a client
            if (clientCreated)
            {
                Console.WriteLine("There's already a client!");
            }
            // If there is no client
            else
            {
                // Set boolean
                clientCreated = true;
                // Create a client
                var newClient = Edge.Func(@"
                    var arDrone = require('ar-drone');
                    var client = arDrone.createClient();
                    return function(data, callback){
                        callback(null, data);
                    }
                ");
                Console.WriteLine("Client created!");
                // Return new client
                return newClient;
            }
            // Return current client
            return currentClient;
        }
