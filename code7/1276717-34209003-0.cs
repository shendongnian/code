        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        namespace UnitTestProject35
        {
            [TestClass]
            public class UnitTest1
            {
                [TestMethod]
                public void TestSuccessParse()
                {
                    HttpResponseCode parsedHttpCode = HttpResponseCode.Unknown;
                    parsedHttpCode.TryParse(200, out parsedHttpCode);
                    Assert.AreEqual(parsedHttpCode, HttpResponseCode.Success);
                }
                [TestMethod]
                public void TestServerErrorParse()
                {
                    HttpResponseCode parsedHttpCode = HttpResponseCode.Unknown;
                    parsedHttpCode.TryParse(500, out parsedHttpCode);
                    Assert.AreEqual(parsedHttpCode, HttpResponseCode.AllServerErrors);
                }                
            }
        
            public enum HttpResponseCode
            {
                Unknown = 0,
                Success = 200,
                MissingParameter = 400,
                //etc...
                AllServerErrors = -1,
                InternalServerError = 500,
                NotImplemented = 501,
                BadGateway = 502,
                //etc..        
            }
            public static class EnumExtensions
            {
                public static void TryParse(this HttpResponseCode theEnum, int code, out HttpResponseCode result)
                {
                    if (code >= 500 && code <= 599)
                    {
                        result = HttpResponseCode.AllServerErrors;                
                    }
                    else
                    {
                        result = (HttpResponseCode)Enum.Parse(typeof(HttpResponseCode), code.ToString());
                    }                                        
                }
            }
        }
