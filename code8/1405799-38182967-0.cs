    public class CrateCrash : MonoBehaviour
    {
        ...
    
        public void InitRespawn(GameObject toRespawn)
        {
            StartCoroutine(RespawnObject(toRespawn, 5.0f));
        }
    
        private IEnumerator RespawnObject(GameObject toRespawn, float delay)
        {
            yield return new WaitForSeconds(delay);
            toRespawn.SetActive(true);
        }
    }
