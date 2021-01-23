    using (var sysConfigRepository = new SysConfigRepository())
    {
        var configs = sysConfigRepository.GetSysConfigs ();
        // Do some stuff here
    }
