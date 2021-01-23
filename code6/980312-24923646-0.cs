    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
            prefab,
            position,
            Quaternion.identity
            ) as ParticleSystem;
    
        newParticalSystem.AddComponent<TimedDestroy>().delay = newParticleSystem.startLifetime;
    
        return newParticleSystem;
    }
