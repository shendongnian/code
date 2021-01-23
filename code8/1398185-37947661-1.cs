    public interface IContextAttributeInspector
    {
        bool ControllerHasAttribute<TAttribute>(ControllerContext controllerContext) where TAttribute : Attribute;
        bool ActionHasAttribute<TAttribute>(ActionDescriptor actionDescriptor) where TAttribute : Attribute;
        bool TryGetControllerAttribute<TAttribute>(ControllerContext controllerContext, out TAttribute attribute) where TAttribute : Attribute;
        bool TryGetActionAttribute<TAttribute>(ActionDescriptor actionDescriptor, out TAttribute attribute) where TAttribute : Attribute;
    }  
    public class ContextAttributeInspector : IContextAttributeInspector
    {
        public bool ControllerHasAttribute<TAttribute>(ControllerContext controllerContext) where TAttribute : Attribute
        {
            return controllerContext.Controller.GetType()
                .GetCustomAttributes(false)
                .Any(attribute => attribute.GetType().IsAssignableFrom(typeof(TAttribute)));
        }
        public bool ActionHasAttribute<TAttribute>(ActionDescriptor actionDescriptor) where TAttribute : Attribute
        {
            return actionDescriptor
                .GetCustomAttributes(typeof(TAttribute), true)
                .Any();
        }
        public bool TryGetControllerAttribute<TAttribute>(ControllerContext controllerContext, out TAttribute attribute) where TAttribute : Attribute
        {
            var foundAttribute = controllerContext.Controller.GetType()
                .GetCustomAttributes(false)
                .FirstOrDefault(customAttribute => customAttribute.GetType().IsAssignableFrom(typeof(TAttribute)));
            if (foundAttribute != null)
            {
                attribute = (TAttribute)foundAttribute;
                return true;
            }
            attribute = null;
            return false;
        }
        public bool TryGetActionAttribute<TAttribute>(ActionDescriptor actionDescriptor, out TAttribute attribute) where TAttribute : Attribute
        {
            var foundAttribute = actionDescriptor
                .GetCustomAttributes(typeof(TAttribute), true)
                .FirstOrDefault();
            if (foundAttribute != null)
            {
                attribute = (TAttribute)foundAttribute;
                return true;
            }
            attribute = null;
            return false;
        }
    }
