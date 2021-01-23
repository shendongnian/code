    public abstract class InterfaceElement : MonoBehaviour
    {
        protected virtual Dictionary<System.Type, System.Type> GetEventHandlers()
        {
            return null;
        }
        public virtual EventHandler GetHandler(System.Type type)
        {
            Dictionary<System.Type, System.Type> eventHandlers = GetEventHandlers();
            if(eventHandlers != null && eventHandlers.ContainsKey(type))
                return this.gameObject.AddComponent(eventHandlers[type]) as EventHandler;
            return null;
        }
    }
    public class Button : InterfaceElement, IOnClick
    {
        protected override Dictionary<System.Type, System.Type> GetEventHandlers()
        {
            return new Dictionary<System.Type, System.Type>()
            {
                {typeof(IOnClick), typeof(OnClickHandler)}
            };
        }
    }
