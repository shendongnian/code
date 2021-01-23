        class Program
        {
            static void Main(string[] args)
            {
                var inputObj = @"{
                         'response': {
                            'status':'success',
                            // Could be either a single object or an array of objects.
                            'data': { 'prop':'value'}
            
                                     }
                                 }";
    
                var inputArray = @"{
                         'response': {
                             'status':'success',
                             // Could be either a single object or an array of objects.
                             'data':[
                                       { 'prop':'value'},
                                       { 'prop':'value'}
                                    ]
                                     }
                                  }";
    
                var obj = JsonConvert.DeserializeAnonymousType(inputObj, new { Response = new Response() });
    
                foreach(var prop in obj.Response.Data)
                    Console.WriteLine(prop);
    
                var arr = JsonConvert.DeserializeAnonymousType(inputArray, new { Response = new Response() });
    
                foreach (var prop in arr.Response.Data)
                    Console.WriteLine(prop);
            }
    }
