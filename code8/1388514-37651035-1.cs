     public class InstantiateExample : MonoBehaviour
        {
            public GameObject prefab;
        
            void Start()
            {
                for (int i = 0; i < 10; i++)
                    Instantiate(prefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
            }
        }
