    public class ParticleHolder : MonoBehaviour
    {
    
        public ParticleSystem[] effects;
        ParticlePool particlePool;
    
        void Start()
        {
            // 0 = Normal crate
            // 1 = TNT crate
            particlePool = new ParticlePool(effects[0], effects[1], 5);
        }
    
        public void playParticle(int particleType, Vector3 particlePos)
        {
            ParticleSystem particleToPlay = particlePool.getAvailabeParticle(particleType);
    
            if (particleToPlay != null)
            {
                if (particleToPlay.isPlaying)
                    particleToPlay.Stop();
    
                particleToPlay.transform.position = particlePos;
                particleToPlay.Play();
            }
    
        }
    }
