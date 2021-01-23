    public class Class1 {
        public static void Start () {
            Debug.Log("hello world");
    
            foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>()) {
                if (go.GetComponent<MeshRenderer>()) {
                    go.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
                }
            }
        }
    }
