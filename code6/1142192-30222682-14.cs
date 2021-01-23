	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Microsoft.ServiceModel.Samples
    {
        public class InMemoryInstances
        {
            private static volatile InMemoryInstances instance;
            private static object syncRoot = new Object();
            private Dictionary<string, string> usersAndTokens = null;
            private InMemoryInstances() 
            {
                usersAndTokens = new Dictionary<string, string>();
            }
            public static InMemoryInstances Instance
            {
                get 
                {
                    if (instance == null) 
                    {
                        lock (syncRoot)                  
                        {
                            if (instance == null) 
                                instance = new InMemoryInstances();
                        }
                    }
                    return instance;
                }
            }
            public void addTokenUserPair(string username, string token)
            {
                usersAndTokens.Add(username, token);
            }
            public bool checkTokenUserPair(string username, string token)
            {
                if (usersAndTokens.ContainsKey(username)) {
                    string value = usersAndTokens[username];
                    if (value.Equals(token))
                        return true;
                }
                return false;
            }
        
            public void removeTokenUserPair(string username)
            {
                usersAndTokens.Remove(username);
            }
        }
    }
