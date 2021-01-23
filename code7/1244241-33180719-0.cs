    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ExternalAPIs_SynapsePay.Helpers
    {
        class RESTHelpers
        {
            public dynamic APICalls(JObject jsonObject, string endpoints, string method)
            {
                HttpWebRequest httpRequest = (HttpWebRequest)HttprequestObject(endpoints, method);
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonObject);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var result = "";
                HttpWebResponse httpResponse;
                try
                {
                    httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine("This program is expected to throw WebException on successful run." +
                                        "\n\nException Message :" + e.Message);
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                        Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                        using (Stream data = e.Response.GetResponseStream())
                        using (var reader = new StreamReader(data))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
    
                return result;
                //return "Success";
                //not sure what to return 
                //here i have to add sql server code to enter into database
            }
    
            public HttpWebRequest HttprequestObject(string endpoints, string method)
            {
                string url = Setting.API_TEST_VALUE + endpoints;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = method;
                return httpWebRequest;
            }
    
            /// <summary>
            /// This method is useful when you have to pass JSON as string not as object... This is basically a constructor..
            /// Even if u pass json object it will accept, so no need to worry about that.
            /// </summary>
            /// <param name="ljson"></param>
            /// <param name="endpoints"></param>
            /// <param name="method"></param>
            /// <returns></returns>
            public dynamic APICalls(string jsonString, string endpoints, string method)
            {
                HttpWebRequest httpRequest = (HttpWebRequest)HttprequestObject(endpoints, method);
                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonString);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var result = "";
                HttpWebResponse httpResponse;
                try
                {
                    httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine("This program is expected to throw WebException on successful run." +
                                        "\n\nException Message :" + e.Message);
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                        Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                        using (Stream data = e.Response.GetResponseStream())
                        using (var reader = new StreamReader(data))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                            result = text;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
    
                return result;
                //return "Success";
                //not sure what to return 
                //here i have to add sql server code to enter into database
            }
            public void HttlpResponseObject(HttpWebRequest httpResponse)
            {
                var response = (HttpWebResponse)httpResponse.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                //entry into databse can be done from here 
                //or it should return some value
            }
        }
    }
