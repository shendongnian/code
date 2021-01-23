      static void Main(string[] args)
            {    
                var userInfos = XElement.Load("file.xml").Descendants("userInfo").Select(elt =>
                {
                    var  line = elt.Descendants();
                    return  string.Join(",", line.Select(subElt => subElt.Value)); 
                });
                foreach (var userInfo in userInfos)
                {
                    Console.WriteLine(userInfo);
                }
    Console.ReadLine();  
                               
            }
