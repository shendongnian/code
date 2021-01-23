    using UnityEngine;
    using System.Collections;
    using UnityStandardAssets.Characters.ThirdPerson;
    
    public class Multiple_objects : MonoBehaviour
    {
        public GameObject prefab;
        public GameObject[] gos;
        public int NumberOfObjects;
    
        private ThirdPersonCharacter[] thirdPersonCharacter;
    
        void Awake()
        {
            thirdPersonCharacter = new ThirdPersonCharacter[2];
    
            gos = new GameObject[NumberOfObjects];
            for (int i = 0; i < gos.Length; i++)
            {
                GameObject clone = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
                gos[i] = clone;
                thirdPersonCharacter[i] = clone.GetComponent<ThirdPersonCharacter>();
            }
        }
    
        // Use this for initialization
        void Start()
        {
    
            thirdPersonCharacter[0].m_MoveSpeedMultiplier = 5f;
            thirdPersonCharacter[1].m_MoveSpeedMultiplier = 5f;
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    }
