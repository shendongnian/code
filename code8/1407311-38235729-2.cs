    public class ParticleHolder : MonoBehaviour
    {
    
        public ParticleSystem[] effects;
    
        public void playParticle(int particleNumber, Vector3 particlePos)
        {
            if (effects != null && effects[particleNumber] != null)
            {
                if (effects[particleNumber].isPlaying)
                    effects[particleNumber].Stop();
    
                ParticleSystem tempPart = Instantiate(effects[particleNumber], particlePos, new Quaternion()) as ParticleSystem;
                tempPart.Play();
            }
    
        }
    }
