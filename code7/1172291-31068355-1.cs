    using System;
    using System.Collections;
    using System.Configuration;
    using Castle.Components.DictionaryAdapter;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Context;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using ConsoleAppStrongTypeConfig;
    
    
    namespace CastleDictionaryAdapterExample
    {
        class Program
        {
            static void Main()
            {
                GetUserSettings();
    
                var programComponent = ContainerRegistrar.Container.Resolve<IProgramServiceConfigDependent>();
    
                programComponent.ConfigDependentAction();
                programComponent = ContainerRegistrar.Container.Resolve<IProgramServiceConfigDependent>();
                programComponent.ConfigDependentAction();
    
                Console.ReadLine();
            }
    
            private static void GetUserSettings()
            {
                ContainerRegistrar.SetupContainer();
    
                Console.WriteLine("Enter setting 1");
                Console.WriteLine();
    
                string setting1 = Console.ReadLine();
    
                Console.WriteLine("Enter setting 2");
                Console.WriteLine();
    
                string setting2 = Console.ReadLine();
                GlobalUserConsoleSettings.consoleSettings = new DictionaryAdapterFactory().GetAdapter<IConsoleSettings>(
                    new Hashtable() { 
                    { "consoleSetting1", setting1 }, 
                    { "consoleSetting2", setting2 } }
                    );
            }
        }
    
        public static class GlobalUserConsoleSettings
        {
            public static IConsoleSettings consoleSettings { get; set; }
        }
    
        public interface IConsoleSettings
        {
            string consoleSetting1 { get; set; }
            int consoleSetting2 { get; set; }
        }
    
        public interface IEnvironmentSettings
        {
            string environmentSetting1 { get; set; }
            int environmentSetting2 { get; set; }
    
            long environmentSettingWhichChanges { get; set; }
        }
    
        public interface IProgramServiceConfigDependent
        {
            void ConfigDependentAction();
        }
        class ProgramServiceConfigDependent : IProgramServiceConfigDependent
        {
            private readonly IConsoleSettings _consoleSettings;
            private readonly IEnvironmentSettings _envSettings;
    
            public ProgramServiceConfigDependent(IConsoleSettings consoleSettings, IEnvironmentSettings envSettings)
            {
                _consoleSettings = consoleSettings;
                _envSettings = envSettings;
            }
    
            public void ConfigDependentAction()
            {
                Console.WriteLine("Doing stuff.");
                Console.WriteLine("Console setting 1 :" + _consoleSettings.consoleSetting1);
                Console.WriteLine("Console setting 2 :" + _consoleSettings.consoleSetting2);
                Console.WriteLine("Environment setting 2 :" + _envSettings.environmentSetting1);
                Console.WriteLine("Environment setting 2 :" + _envSettings.environmentSetting2);
                Console.WriteLine("Environment setting which changes with time :" + _envSettings.environmentSettingWhichChanges);
            }
        }
    
        public static class ContainerRegistrar
        {
            internal static WindsorContainer Container { get; set; }
    
            public static void SetupContainer()
            {
                var container = new WindsorContainer();
                container.AddFacility<TypedFactoryFacility>();
    
                container.Register(
                   Component.For<IConsoleSettings>().UsingFactoryMethod(GetGlobalUserConsoleSettings),
                    Component.For<IEnvironmentSettings>().UsingFactoryMethod(GetLiveEnvironmentSettings).LifestyleTransient(),
                    Component.For<IProgramServiceConfigDependent>().ImplementedBy<ProgramServiceConfigDependent>().LifestyleTransient()
                    );
    
                Container = container;
            }
    
            private static IConsoleSettings GetGlobalUserConsoleSettings(IKernel k, CreationContext c)
            {
                return GlobalUserConsoleSettings.consoleSettings;
            }
    
            private static IEnvironmentSettings GetLiveEnvironmentSettings(IKernel k, CreationContext c)
            {
                string envSet1 = Environment.CurrentDirectory;
                int envSet2 = Environment.OSVersion.Version.Major;
    
                long envSet3 = DateTime.UtcNow.Ticks;
                IEnvironmentSettings envSet = new DictionaryAdapterFactory().GetAdapter<IEnvironmentSettings>(
                    new Hashtable() { 
                    { "environmentSetting1", envSet1 }, 
                    { "environmentSetting2", envSet2 },
                    { "environmentSettingWhichChanges", envSet3}}
                    );
    
                return envSet;
            }
        }
    }
