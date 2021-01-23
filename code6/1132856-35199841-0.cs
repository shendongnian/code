    /// <summary>
    /// This extension allows the changing of the default lifetime manager in unity.
    /// </summary>
    public class DefaultLifetimeManagerExtension<T> : UnityContainerExtension where T : LifetimeManager
    {
        /// <summary>
        /// Handle the registering event
        /// </summary>
        protected override void Initialize()
        {
            Context.Registering += this.OnRegister;
        }
        /// <summary>
        /// Remove the registering event
        /// </summary>
        public override void Remove()
        {
            Context.Registering -= this.OnRegister;
        }
        /// <summary>
        /// Handle the registration event by checking for null registration
        /// </summary>
        private void OnRegister(object sender, RegisterEventArgs e)
        {
            if (e.LifetimeManager == null)
            {
                var lifetimeManager = (LifetimeManager)Activator.CreateInstance(typeof (T));
                // Set this internal property using reflection
                lifetimeManager
                    .GetType()
                    .GetProperty("InUse", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(lifetimeManager, true);
                Context.Policies.Set<ILifetimePolicy>(lifetimeManager, new NamedTypeBuildKey(e.TypeTo, e.Name));
                if (lifetimeManager is IDisposable)
                {
                    Context.Lifetime.Add(lifetimeManager);
                }
            }
        }
    }
