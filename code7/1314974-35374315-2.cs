    //This method cast to object
    public static Route MapRoute(this RouteCollection routes, string name, string url)
    {
        return MapRoute(routes, name, url, null /* defaults */, (object)null /* constraints */);
    }
    //This method does not
    public static Route MapRoute(this RouteCollection routes, string name, string url, string[] namespaces)
    {
        return MapRoute(routes, name, url, null /* defaults */, null /* constraints */, namespaces);
    }
