            if (!Resolver.IsSet)
            {
                var container = new SimpleContainer();
                container.Register<IJsonSerializer, XLabs.Serialization.JsonNET.JsonSerializer>();
                Resolver.SetResolver(container.GetResolver());
            }
