     using System;
     using System.Threading.Tasks;
     using EdgeJs;
      class Program
      {
        public static async Task Start()
       {
         var func = Edge.Func(@"
         return function (data, callback) {
         var error = '';
         var hello = function() { 
         try{
                 some javascript syntax error .... 
                 return 'Hello ' + data;
         }catch(e){ error = e;}
                 };
         var result = hello();
         if(error == '')
         {
              callback(null, result );
         } else { 
                   callback(null, error);
                }
         }
        ");
         Console.WriteLine(await func("Word!"));
       }
      static void Main(string[] args)
      {
          Start().Wait();
      }
    }
