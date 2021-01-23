    #pragma strict
    
    public static var lastSoundTime : float = 0;
    public var force:float = 1;
    
    private var m_CollisionEvents : ParticleCollisionEvent[] = new ParticleCollisionEvent[16];
    private  var m_ParticleSystem : ParticleSystem;
    
    function Start () {
        m_ParticleSystem = this.gameObject.GetComponent(ParticleSystem);
    }
    
    function Update () {
    
    }
