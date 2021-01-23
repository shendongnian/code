    public class GetTransform : MonoBehaviour
    {    
        Transform GetEnumTransform(BodyBones bodyBone)
        {            
            return bodyBone.GetBodyBoneTransform();
        }
    
    }
    class BodyBones
    {
         protected Transform _transform;
         
         public BodyBones(Transform transform)
         {
             _transform = transform;
         }
         public Transform GetBodyBoneTransform()
         {
             return _transform;
         }
    }
    class JtPelvis : BodyBones
    {
         public JtPelvis (Transform transform): base(transform)
    }
    class JtPelvis : BodyBones
    {
         public JtSkull (Transform transform): base(transform)
    }
