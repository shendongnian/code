    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.IO;
    namespace SExperiment
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                try{
                    string webAddr="http://gurujsonrpc.appspot.com/guru";
                    
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                    httpWebRequest.ContentType = "application/json; charset=utf-8";
                    httpWebRequest.Method = "POST";    
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{ \"method\" : \"guru.test\", \"params\" : [ \"Guru\" ], \"id\" : 123 }";
                        
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var responseText = streamReader.ReadToEnd();
                        Console.WriteLine(responseText);
                        //Now you have your response.
                        //or false depending on information in the response     
                    }
                }catch(WebException ex){
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
