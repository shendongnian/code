    public static void SetFakeSession(this HttpContext httpContext)
    {
        var sessionContainer = new HttpSessionStateContainer("id", 
                                                 new SessionStateItemCollection(),
                                                 new HttpStaticObjectsCollection(), 10, true,
                                                 HttpCookieMode.AutoDetect,
                                                 SessionStateMode.InProc, false);
        httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                                 BindingFlags.NonPublic | BindingFlags.Instance,
                                                 null, CallingConventions.Standard,
                                                 new[] { typeof(HttpSessionStateContainer) },
                                                 null)
                                            .Invoke(new object[] { sessionContainer });
    }
