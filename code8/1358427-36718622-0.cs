    System.Web.SessionState.SessionIDManager manager = new System.Web.SessionState.SessionIDManager();
                        string newCaller = manager.CreateSessionID(HttpContext.Current);
                        bool isAdded = false;
                        bool isRedirect = false;
                        manager.SaveSessionID(HttpContext.Current, newCaller, out isRedirect, out isAdded);
                        SessionID = newCaller;
