        try {
            using (ServerManager serverManager = new ServerManager())
            {
                var config = serverManager.GetApplicationHostConfiguration();
                // Configure IIS to compress for requests coming through proxies (CDN).
                var httpCompressionSection = config.GetSection("system.webServer/httpCompression");
                httpCompressionSection["noCompressionForHttp10"] = false;
                httpCompressionSection["noCompressionForProxies"] = false;
                httpCompressionSection["staticCompressionIgnoreHitFrequency"] = true;
                // Configure IIS threshold and time-period for compression
                var serverRuntimeSection = config.GetSection("system.webServer/serverRuntime");
                serverRuntimeSection["frequentHitThreshold"] = 1;
                serverRuntimeSection["frequentHitTimePeriod"] = new TimeSpan(24, 0, 0); // 1 day
                // Configure IIS to compress files beforehand
                var urlCompressionSection = config.GetSection("system.webServer/urlCompression");
                urlCompressionSection["dynamicCompressionBeforeCache"] = true;
                serverManager.CommitChanges();
            }
        } catch (Exception e)
        {
            _log.ErrorFormat("Exception thrown during configuration! : {0}", e.ToString());
        }
