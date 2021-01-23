    …
    catch (Exception ex)
    {
        var version = GetType().Assembly.GetName().Version.ToString();
        ThreadContext.Properties["version"] = version;
        log.Error(ex);
    }
