    static void AddFileToRequest(
        HttpRequest request, string fileName, string contentType, byte[] bytes)
    {
        var fileSize = bytes.Length;
        // Because these are internal classes, we can't even reference their types here
        var uploadedContent = ReflectionHelpers.Construct(typeof (HttpPostedFile).Assembly,
            "System.Web.HttpRawUploadedContent", fileSize, fileSize);
        uploadedContent.InvokeMethod("AddBytes", bytes, 0, fileSize);
        uploadedContent.InvokeMethod("DoneAddingBytes");
        var inputStream = ReflectionHelpers.Construct(typeof (HttpPostedFile).Assembly,
            "System.Web.HttpInputStream", uploadedContent, 0, fileSize);
        var postedFile = ReflectionHelpers.Construct<HttpPostedFile>(fileName, 
                 contentType, inputStream);
        // Accessing request.Files creates an empty collection
        request.Files.InvokeMethod("AddFile", fileName, postedFile);
    }
    public static object Construct(Assembly assembly, string typeFqn, params object[] args)
    {
        var theType = assembly.GetType(typeFqn);
        return theType
          .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, 
                 args.Select(a => a.GetType()).ToArray(), null)
          .Invoke(args);
    }
    public static T Construct<T>(params object[] args) where T : class
    {
        return Activator.CreateInstance(
            typeof(T), 
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
            null, args, null) as T;
    }
    public static object InvokeMethod(this object o, string methodName, 
         params object[] args)
    {
        var mi = o.GetType().GetMethod(methodName, 
                 BindingFlags.NonPublic | BindingFlags.Instance);
        if (mi == null) throw new ArgumentOutOfRangeException("methodName",
            string.Format("Method {0} not found", methodName));
        return mi.Invoke(o, args);
    }
