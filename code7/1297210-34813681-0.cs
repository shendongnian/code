    public class PlaceableObject : MonoBehaviour 
    {
        int CollidersInTrigger = 0;
        void OnTriggerEnter(Collider col)
        {
            CollidersInTrigger++;
        }
        void OnTriggerExit(Collider other) 
        {
            CollidersInTrigger--;
        }
        bool CanPlace()
        {
            return CollidersInTrigger == 0;
        }
    }
