    using (ClientContext clientContext = new ClientContext(urlSite))
                {
                    clientContext.Credentials = new NetworkCredential(user, pwd, domain);
                    Web web = clientContext.Web;
                    clientContext.Load(web);
                    clientContext.ExecuteQuery();
                    Console.WriteLine(web.Title);
                    Console.ReadLine();
                }
