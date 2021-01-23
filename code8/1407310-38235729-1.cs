    public class ParticlesContainer : MonoBehaviour
    {
        public ParticleSystem[] effects;
    
        public void playParticle(int particleNumber, Vector3 particlePos)
        {
            if (effects != null && effects[particleNumber] != null)
            {
                if (effects[particleNumber].isPlaying)
                    effects[particleNumber].Stop();
    
                effects[particleNumber].transform.position = particlePos;
                effects[particleNumber].Play();
            }
        }
    }
