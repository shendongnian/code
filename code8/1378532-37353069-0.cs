    #r "DependencyWithJsonRef.dll"
    using System.Net;
    public static string Run(HttpRequestMessage req, TraceWriter log)
    {
        var myType = new DependencyWithJsonRef.TestType();
        return myType.GetFromJson();
    }
