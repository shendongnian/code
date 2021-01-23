    public class CollisionController:MonoBehaviour{
        private void Awake(){
           foreach(Transform t in transform){
               if(t == this.transform) { continue; }
               t.gameObject.AddComponent<CollisionMethod>();
           }
        }
    }
