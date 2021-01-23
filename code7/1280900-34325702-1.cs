    using System;
    using Castle.MicroKernel.ComponentActivator;
    using DevExpress.Mvvm.DataAnnotations;
    using DevExpress.Mvvm.Native;
    using DataAbstractWPF.Helpers;
    
    namespace DataAbstractWPF.Activators
    {
        class DXViewModelActivator : DefaultComponentActivator
        {
            public DXViewModelActivator(Castle.Core.ComponentModel model, Castle.MicroKernel.IKernelInternal kernel, Castle.MicroKernel.ComponentInstanceDelegate onCreation, Castle.MicroKernel.ComponentInstanceDelegate onDestruction)
                : base(model, kernel, onCreation, onDestruction)
            {
                Model.Implementation = TryGetPOCOType(Model.Implementation);
            }
    
            Type TryGetPOCOType(Type implementation)
            {
                if (AttributeHelper.HasAttribute(implementation, typeof(POCOViewModelAttribute)))
                    implementation = ViewModelSourceHelper.GetProxyType(implementation);
                
                return implementation;
            }
    
        }
    }
