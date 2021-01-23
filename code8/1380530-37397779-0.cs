    public class NewBehaviourScript1 : MonoBehaviour
    {
        public Script script; //Drag the other cube onto this in the inspector.
    
        void OnMouseDown() 
        {
            if ( script.test == 1) 
            {
                Destroy(gameObject); 
            }
        }
    }
