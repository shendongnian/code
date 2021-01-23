    using System;
    using Microsoft.Practices.ObjectBuilder2;
    using Microsoft.Practices.Unity;
    public class Remember : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Context.Registering += this.OnRegistering;
            this.Context.RegisteringInstance += this.OnRegisteringInstance;
        }
        private void OnRegisteringInstance(object sender, RegisterInstanceEventArgs e)
        {
            if(string.IsNullOrEmpty(e.Name))
            {
                string uniqueName = Guid.NewGuid().ToString();
                this.Context.RegisterNamedType(e.RegisteredType, uniqueName);
                this.Context.Policies.Set<IBuildKeyMappingPolicy>(
                    new BuildKeyMappingPolicy(new NamedTypeBuildKey(e.RegisteredType)), 
                    new NamedTypeBuildKey(e.RegisteredType, uniqueName));
            }
        }
        private void OnRegistering(object sender, RegisterEventArgs e)
        {
            if (e.TypeFrom != null && string.IsNullOrEmpty(e.Name))
            {
                string uniqueName = Guid.NewGuid().ToString();
                this.Context.RegisterNamedType(e.TypeFrom, uniqueName);
                if (e.TypeFrom.IsGenericTypeDefinition && e.TypeTo.IsGenericTypeDefinition)
                {
                    this.Context.Policies.Set<IBuildKeyMappingPolicy>(
                        new GenericTypeBuildKeyMappingPolicy(new NamedTypeBuildKey(e.TypeTo)),
                        new NamedTypeBuildKey(e.TypeFrom, uniqueName));
                }
                else
                {
                    this.Context.Policies.Set<IBuildKeyMappingPolicy>(
                        new BuildKeyMappingPolicy(new NamedTypeBuildKey(e.TypeTo)),
                        new NamedTypeBuildKey(e.TypeFrom, uniqueName));
                }
            }
        }
    }
