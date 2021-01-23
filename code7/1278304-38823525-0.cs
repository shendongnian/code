    using  System;
    using  System.Net;
    using  System.IO;
    
    namespace ConsoleApplication5{
        class Program    {
            static void Main(string[] args){                
                string[] linefrompastebin = new string[100];
                string useridstring = "76561198079483032";
                int i = 0;
                int maxLines = 0;
                bool _isAllowed = false;
    
                var url = "http://pastebin.com/raw/fTgJF857";
                var client = new WebClient();
    
                Console.WriteLine("Reading HTML at :  http://pastebin.com/raw/fTgJF857 \n\n");
    
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream)) {
                linefrompastebin[0] = "";
                
                //Store lines from HTML into string
                while ((linefrompastebin[i] = reader.ReadLine()) != null){
                    i++;
                }
                maxLines = i;
                }
    
                //do some line processing - compare user with whitelist
                for (i = 0; i < maxLines;i++ ){
                    Console.WriteLine(linefrompastebin[i]);
    
                    if(linefrompastebin[i] == useridstring){
                        _isAllowed = true;
                        Console.WriteLine("\n");
                        Console.WriteLine("_isAllowed = true on -> "+ linefrompastebin[i]+ ". user Exists in database");
                     }
    
                }
                
                linefrompastebin = null;
                Console.WriteLine("\n\n");
                Console.ReadLine();
    
    
            }
        }
    }
