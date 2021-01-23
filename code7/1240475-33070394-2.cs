    using System.Reflection;
    using System.Diagnostics;
    ...
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            // Reflection code...
            var t = typeof(string).GetTypeInfo();
            Debug.WriteLine(t.IsEnum);
            Debug.WriteLine(t.IsPrimitive);
            Debug.WriteLine(t.IsGenericType);
            Debug.WriteLine(t.IsPublic);
            Debug.WriteLine(t.IsNestedPublic);
            Debug.WriteLine(t.BaseType.AssemblyQualifiedName);
            Debug.WriteLine(t.IsValueType);
        }
