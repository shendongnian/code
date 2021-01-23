    public class GetTransform : MonoBehaviour
    {
        public Transform headBone;
        public Transform pelvisBone;
    
        private Dictionary<myBonesBody,Transform> mEnumToBone;
    
        void Start() {
             mEnumToBone=new Dictionary<myBonesBody,Transform>();
             mEnumToBone.Add(myBodyBone.skull,headBone); //Continue as such.
    
             mEnumToBone[myBodyBone.skull];   //This is how you retrieve the value from the dictionary
        }
        public Transform GetTransform(myBonesBody part) {
            return mEnumToBone[part];
       }
    }
