           public static string getChildren(int myID){
                    using (var rep = new context()) {
                    Header head = rep.Headers.Where(x => x.ID== myID).First();
                    
                    var details = head.Details.ToList();
                    }
           // Convert List to JSON and return to client
                    string myChidren="";
                    return myChildren;
           }
