            public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController)_container.Resolve(controllerType);
            // Controller disposal ensures new controller for each request, hence DbContexts are fresh and pull fresh data from the DB.
            request.RegisterForDispose(
                new Release(
                    () => _container.Release(controller)));
            return controller;
        }
        private class Release : IDisposable
        {
            private readonly Action _release;
            public Release(Action release)
            {
                _release = release;
            }
            public void Dispose()
            {
                _release();
            }
        }
