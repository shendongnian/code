    public class EndCollider : MonoBehaviour {
    
    public GameObject MonsterPrefab;
    
    void OnTriggerEnter ()
    {
        Instantiate(MonsterPrefab);
    }
    
    }
