        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Event>(context, Request, Services);
            //Add these lines
            var service = Configuration.Services.GetServices(typeof(IFilterProvider)).ToList();
            service.Remove(service.FirstOrDefault(f => f.GetType() == typeof(TableFilterProvider)));
            service.Add(new TableFilterProvider(new CustomEnableQueryAttribute()));
            Configuration.Services.ReplaceRange(typeof(IFilterProvider), service.ToList().AsEnumerable());
            Request.Properties.Add("MS_IsQueryableAction", true);
        }
