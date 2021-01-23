    public class DeathListener : MonoBehaviour {
    public HealthManager _hm;
    void Awake(){
      _hm = GetComponent<HealthManager>();
    }
    // Add event listeners when object gets enabled
    void OnEnable () {
        _hm.OnObjectDeath += Died;
    }
    // Remove event listeners when object gets disabled
    void OnDisable () {
       _hm.OnObjectDeath -= Died;
    }
    void Died(){
        
            Destroy(gameObject);
        
    } }
