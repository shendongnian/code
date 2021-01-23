    public class Test : MonoBehaviour {
        public int foobar;
    }
    public static T CreateAndAttach<T>(Action<T> init)
         where T : MonoBehaviour
    {
        GameObject go = new GameObject();
        T t = go.AddComponent<T>();
        init(t);
        return t;
    }
    //usage
    CreateAndAttach<Test>(t => { t.foobar = 10; });   
