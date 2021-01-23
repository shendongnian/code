        public static async void blinkGreen()
        {
            // Get an existing or new client
            var client = GetOrCreateClient();
            // Execute the functionality
            var func = Edge.Func(@"             
                var arDrone = require('ar-drone'); // ACTUALLY THIS ONE IS ALREADY DEFINED IN THE METHOD GetOrCreateClient()
                var client = I WANT HERE THE CLIENT, BUT HOW?
                return function(data, callback){
                    client.animateLeds('blinkGreen',5,2);
                    callback(null, data);
                }
            ");
            Console.WriteLine(await func("BLINK EXECUTED!"));
        }
