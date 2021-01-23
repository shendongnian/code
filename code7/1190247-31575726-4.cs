    public class WallScript : MonoBehaviour
    {
        [HideInInspector]  //Optional Attribute
        public bool collidedWithPlayer;
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "Player")
            {
                collidedWithPlayer = true;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if(collision.gameObject.name == "Player")
            {
                collidedWithPlayer = false;
            }
        }
           //We don't want "collidedwithPlayer" to remain true if either of the walls touches the player before both do so we call "OnCollisionExit" to set it to false.
    }
