    container.Register(
                Component.For<IOrganisationDomainDbContext>().ImplementedBy<OrganisationDomainDbContext>().LifeStyle.PerWebRequest, 
                Component.For<Func<IOrganisationDomainDbContext>>().Instance(container.Resolve<IOrganisationDomainDbContext>), 
                Component.For<IOrganisationRepository>().ImplementedBy<OrganisationRepository>().LifeStyle.PerWebRequest, 
                Classes.FromThisAssembly().BasedOn<ApiController>().LifestylePerWebRequest());
