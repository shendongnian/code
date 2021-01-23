    class ProgramNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PersonalityConfiguration>().ToSelf().InSingletonScope();
            Bind<IPersonalityProvider>().ToMethod(n => n.Kernel.Get<PersonalityConfiguration>()).WhenInjectedInto<Person>();
        }
    }
