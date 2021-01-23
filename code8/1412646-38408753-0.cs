    using UnityEngine;
    using System.Collections;
    
    public class CreatePlayer : MonoBehaviour
    {
    
        public GameObject objPlayer;
        public GameObject objLimb;
        public GameObject objAdded;
    
    
        // Use this for initialization
        void Start()
        {
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
                AddLimb(objLimb, objPlayer);
            if (Input.GetKeyDown(KeyCode.J))
                Destroy(objAdded);
        }
    
        // 
    
        void AddLimb(GameObject BonedObj, GameObject RootObj)
        {
            var BonedObjects = BonedObj.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer SkinnedRenderer in BonedObjects)
            {
                ProcessBonedObject(SkinnedRenderer, RootObj);
            }
        }
    
        private void ProcessBonedObject(SkinnedMeshRenderer ThisRenderer, GameObject RootObj)
        {
            /*      Create the SubObject        */
            var NewObj = new GameObject(ThisRenderer.gameObject.name);
            NewObj.transform.parent = RootObj.transform;
            /*      Add the renderer        */
            NewObj.AddComponent<SkinnedMeshRenderer>();
            var NewRenderer = NewObj.GetComponent<SkinnedMeshRenderer>();
            /*      Assemble Bone Structure     */
            var MyBones = new Transform[ThisRenderer.bones.Length];
            for (var i = 0; i < ThisRenderer.bones.Length; i++)
                MyBones[i] = FindChildByName(ThisRenderer.bones[i].name, RootObj.transform);
            /*      Assemble Renderer       */
            NewRenderer.bones = MyBones;
            NewRenderer.sharedMesh = ThisRenderer.sharedMesh;
            NewRenderer.materials = ThisRenderer.materials;
            objAdded = NewObj;
        }
    
        
        private Transform FindChildByName(string ThisName,Transform ThisGObj)
        {
            Transform ReturnObj;
            if( ThisGObj.name==ThisName )
                return ThisGObj.transform;
            foreach (Transform child in ThisGObj)
            {
                ReturnObj = FindChildByName( ThisName, child );
                if( ReturnObj )
                    return ReturnObj;
            }
            return null;
        }
    }
