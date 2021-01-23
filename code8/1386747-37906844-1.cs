    public class MyDomainServiceFactory : IDomainServiceFactory
    {
        
        public DomainService CreateDomainService(Type domainServiceType, DomainServiceContext context)
        {
            var service = Global.UnityContainer.Resolve(domainServiceType) as DomainService;
            service.Initialize(context);
            return service;
        }
        public void ReleaseDomainService(DomainService domainService)
        {
            domainService.Dispose();
        }
    }
