        private String GetMonoRuntime()
    {
        Type type = Type.GetType("Mono.Runtime");
        if (type != null)
        {
            MethodInfo displayName = type.GetMethod("GetDisplayName", BindingFlags.NonPublic | BindingFlags.Static);
            if (displayName == null)
                return "Unix/Linux + Mono";
            else
                return "Unix/Linux + Mono " + displayName.Invoke(null, null);
        }
        return String.Empty;
    }
