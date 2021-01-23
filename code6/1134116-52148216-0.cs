                           new HttpResponse()
                           {
                               RequestUri = string.Empty,
                               StatusCode = HttpStatusCode.OK,
                               Cookies = new CookieCollection()
                               {
                                   new Cookie("MyCookie", cookie)
                               },
                               Headers = new WebHeaderCollection()
                               {
                                   "X-Powered-By:Servlet/3.1 JSP/2.3 (Payara Server  4.1.1.162 #badassfish Java/Oracle Corporation/1.8)"
                               }
                           }
