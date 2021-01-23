    public class Test: MonoBehaviour
    {
        public GameObject[] RedgeSets;
        private GameObject lastInstanceObj;
        bool firstRun = true;
    
        void Update()
        {
            Vector3 addheight = new Vector3(0, 5, 0);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (firstRun)
                {
                    lastInstanceObj = Instantiate(RedgeSets[UnityEngine.Random.Range(0, RedgeSets.Length)], addheight, Quaternion.identity) as GameObject;
                    firstRun = false;
                }
                else
                {
                    lastInstanceObj = Instantiate(RedgeSets[UnityEngine.Random.Range(0, RedgeSets.Length)], lastInstanceObj.transform.position + addheight, Quaternion.identity) as GameObject;
                }
            }
        }
    }
