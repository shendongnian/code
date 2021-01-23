    using UnityEngine;
    public class SpeedBoostPowerUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider c)
        {
            if(c.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
