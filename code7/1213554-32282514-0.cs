    public class BaseClass : MonoBehavior {
        void Update() {
            //my connectionhandler
        }
    
        public BaseClass() {
            Debug.Assert(!OverridesUpdateMethod(), "Do not override Update()!");
        }
    
        [Debug]
        private bool OverridesUpdateMethod() {
            return GetType() != typeof(BaseClass) &&
                   GetType().GetMethod("Update", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) != null;
        }
    }
