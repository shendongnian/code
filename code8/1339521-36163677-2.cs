    public class NoDestory : MonoBehaviour
    {
        private static Dictionary<string, GameObject> _instances = new Dictionary<string, GameObject>();
        public string ID; // HACK: This ID can be pretty much anything, as long as you can set it from the inspector
        
        void Awake()
        {
            if(_instance.ContainsKey(ID))
            {
                var existing = _instances[ID];
                
                // A null result indicates the other object was destoryed for some reason
                if(existing != null)
                {
                    if(ReferennceEquals(gameObject, existing)
                        return;
                    Destory(gameObject);
                    // Return to skip the following registration code
                    return;
                }
            }
            // The following code registers this GameObject regardless of whether it's new or replacing
            _instances[ID] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }
