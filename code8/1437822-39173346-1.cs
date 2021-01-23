    public class UnityControllerActivator : IControllerActivator
    {
        private IUnityContainer _unityContainer;
        public UnityControllerActivator(IUnityContainer container)
        {
            _unityContainer = container;
        }
        #region Implementation of IControllerActivator
        public object Create(ControllerContext context)
        {
            return _unityContainer.Resolve(context.ActionDescriptor.ControllerTypeInfo.AsType());
        }
        
        public void Release(ControllerContext context, object controller)
        {
            //ignored
        }
        #endregion
    }
