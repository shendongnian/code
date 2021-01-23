    public static void mclInitializeApplication(params string[] options)
    {
        var count = 0;
        if (options != null) { count = options.Length; }
        if (!_mclInitializeApplication(options, count))
        {
            var reason = mclGetLastErrorMessage();
			throw new Exception(String.Format("Call to '{0}' failed: {1}", "mclInitializeApplication", reason));               
        }
    }
