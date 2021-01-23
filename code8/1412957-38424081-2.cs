    using UnityEngine;
    
    public class inventory : MonoBehaviour {
    
        public bool displayInventory;
    
        public Behaviour PlayerController;
    
        public int currentPrefabId;
    
        public GameObject playerInv;
    
        public Transform playerTransform;
    
        public Vector3 playerPosition;
    
        public GameObject m_oPlayer // <- NEW! : Must be linked in the editor with the player (RigidBodyFPSController);
    
        public GameObject m_oWoodPrefab; // <- NEW! :Must be linked in the editor with the prefab
    
        void Start () {
            displayInventory = false;
            playerPosition = playerTransform.position;
        }
    
        void FixedUpdate() {
    
            playerPosition = playerTransform.position;
    
            if (Input.GetButtonDown("Open Inventory"))
            {
                displayInventory = true;
    
            }
    
            if (Input.GetButtonDown("Cancel"))
            {
                displayInventory = false;
            }
    
            if (displayInventory == true)
            {
                showInventory(playerInv);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
    
            if (displayInventory == false)
            {
                closeInventory(playerInv);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
    
            if (Input.GetButton("Fire1"))
            {
                Sign.placePrefabSign();
            }
    
            if (Input.GetButtonDown("Fire2")) // <- CHANGED
            {
                Instantiate(m_oWoodPrefab, playerPosition, m_oPlayer.transform.rotation);
            }
        }
    
        public static void showInventory(GameObject playerInv)
        {
            playerInv.SetActive(true);  
        }
    
        public static void closeInventory(GameObject playerInv)
        {
            playerInv.SetActive(false);
        }
    
        public static void PlacePrefab(int currentPrefabId, GameObject[] Prefabs, Vector3 playerPosition)
        {
            Instantiate(Prefabs[currentPrefabId], playerPosition, new Quaternion(0, 0, 0, 0));
        }
    
    }
