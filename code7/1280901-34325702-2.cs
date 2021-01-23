    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using DataAbstractWPF.Helpers;
    using DevExpress.Mvvm.DataAnnotations;
    using DataAbstractWPF.Activators;
    
    namespace DataAbstractWPF.Bootstrapping
    {
        public class Installers : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
    
                container.Register(Classes.FromThisAssembly()
                    .Where(type => AttributeHelper.HasAttribute(type, typeof(POCOViewModelAttribute)))
                    .Configure(r => r.Activator<DXViewModelActivator>())
                    .LifestyleTransient()
                    .WithServiceDefaultInterfaces()
                    );
    
                container.Register(Component.For<Interfaces.ICreateEntityWizard>().ImplementedBy<Views.CreateEntityWizard>().LifestyleTransient());
                container.Register(Component.For<Interfaces.IMainWindow>().ImplementedBy<Views.MainWindow>().LifestyleTransient());
                container.Register(Component.For<Interfaces.ICreateEntityKind>().ImplementedBy<Views.CreateEntityKind>().LifestyleTransient());
    
                container.Register(Component.For<Interfaces.IShell>().ImplementedBy<Shell>().LifestyleTransient());
            }
    
        }
    }
