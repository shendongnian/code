        private IFileProvider GetFileProvider(IServiceProvider requestServices)
        {
            if (FileProvider != null)
            {
                return FileProvider;
            }
            var hostingEnvironment = requestServices.GetService<IHostingEnvironment>();
            FileProvider = hostingEnvironment.WebRootFileProvider;
            return FileProvider;
        }
    }
  
