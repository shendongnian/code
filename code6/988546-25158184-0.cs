      private static void Main(string[] args)
            {
    
                string s = "{email:ss@ss.com}{id:AB12345}";
                string email = string.Empty;
                string id = string.Empty;
                FillValue(s, out email, out id);
                Console.WriteLine("email:{0}\nid:{1}",email,id);
                  Console.ReadKey();
            }
    
            private static void FillValue(string s, out string email, out string id)
            {
                var values = s.Replace("}{", "$").Replace("{",string.Empty).Replace("}",string.Empty).Split('$');
                email = values[0].Split(':')[1];
                id = values[1].Split(':')[1];
            }
