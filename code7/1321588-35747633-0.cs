    public interface IFoo { }
    public interface IBar { }
    public interface IBaz { }
    /// <summary>
    /// Needed to invoke the plugin
    /// </summary>
    public interface IPlugin
    {
        void Invoke();
    }
    public class Plugin1 : IPlugin
    {
        public readonly IFoo Foo;
        public Plugin1([NotNull] IFoo foo)
        {
            if (foo == null) throw new ArgumentNullException("foo");
            this.Foo = foo;
        }
        public void Invoke()
        {
            ;
        }
    }
    public class Plugin2 : IPlugin
    {
        public readonly IBar Bar;
        public readonly IBaz Baz;
        public Plugin2([NotNull] IBar bar, [NotNull] IBaz baz)
        {
            if (bar == null) throw new ArgumentNullException("bar");
            if (baz == null) throw new ArgumentNullException("baz");
            this.Bar = bar;
            this.Baz = baz;
        }
        public void Invoke()
        {
            ;
        }
    }
    public class Plugin3 : IPlugin
    {
        public readonly IBar Bar;
        public readonly IBaz Baz;
        public Plugin3([NotNull] IBar bar, [CanBeNull] IBaz baz = null)
        {
            if (bar == null) throw new ArgumentNullException("bar");
            this.Bar = bar; ;
            this.Baz = baz;
        }
        public void Invoke()
        {
            ;
        }
    }
    public class Bar : IBar
    {
    }
    public class SampleHostTest
    {
        [Fact]
        void SampleHostCanResolvePlugin3ButNot1And2()
        {
            var bar = new Bar();
            var plugins = Assembly.GetAssembly(typeof(SampleHost))
                    .GetTypes()
                    .Where(t => t.IsClass && typeof(IPlugin).IsAssignableFrom(t))
                    .ToArray();
            var sut = new SampleHost(bar, plugins);
            
            sut.IsPluginSupported(typeof(Plugin1)).ShouldBeFalse();
            sut.IsPluginSupported(typeof(Plugin2)).ShouldBeFalse();
            sut.IsPluginSupported(typeof(Plugin3)).ShouldBeTrue();
        }
        [Fact]
        void ResolvePlugin3()
        {
            var bar = new Bar();
            var plugins = Assembly.GetAssembly(typeof(SampleHost))
                    .GetTypes()
                    .Where(t => t.IsClass && typeof(IPlugin).IsAssignableFrom(t))
                    .ToArray();
            var sut = new SampleHost(bar, plugins);
            sut.IsPluginSupported(typeof(Plugin3)).ShouldBeTrue();
            sut.CreateAndInvokePlugin(typeof(Plugin3));
            // no exception => succeeded
        }
    
    
    }
    public class SampleHost
    {
        private readonly IBar bar;
        private readonly IWindsorContainer container;
        private Type[] plugins;
        public SampleHost(IBar bar, IEnumerable<Type> plugins)
        {
            this.bar = bar;
            this.plugins = plugins.ToArray();
            this.container = new WindsorContainer();
            container.Register(Component.For<IBar>().Instance(this.bar));
            foreach (var plugin in this.plugins)
            {
                container.Register(Component.For(plugin).ImplementedBy(plugin).LifestyleTransient());
            }
        }
        public bool IsPluginSupported(Type type)
        {
            var result = container.Kernel.HasComponent(type) &&
                         container.Kernel.GetHandler(type).CurrentState == HandlerState.Valid;
            return result;
        }
        public void CreateAndInvokePlugin(Type type)
        {
            Assert.True(IsPluginSupported(type));
            var plugin = container.Resolve(type)as IPlugin;
            Debug.Assert(plugin != null, "plugin != null");
            plugin.Invoke();
        }
    }
