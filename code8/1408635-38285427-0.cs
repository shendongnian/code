    using UnityEngine;
    using System.Collections;
    using System;
    
    public class ParticlePool
    {
        int particleAmount;
        ParticleSystem[] NormalParticle;
        ParticleSystem[] TNTParticle;
    
        public ParticlePool(ParticleSystem normalPartPrefab, ParticleSystem tntPartPrefab, int amount = 10)
        {
            particleAmount = amount;
            NormalParticle = new ParticleSystem[particleAmount];
            TNTParticle = new ParticleSystem[particleAmount];
    
            for (int i = 0; i < particleAmount; i++)
            {
                //Instantiate 10 NormalParticle
                NormalParticle[i] = GameObject.Instantiate(normalPartPrefab, new Vector3(0, 0, 0), new Quaternion()) as ParticleSystem;
    
                //Instantiate 10 TNTParticle
                TNTParticle[i] = GameObject.Instantiate(tntPartPrefab, new Vector3(0, 0, 0), new Quaternion()) as ParticleSystem;
            }
        }
    
        //Returns available GameObject
        public ParticleSystem getAvailabeParticle(int particleType)
        {
            ParticleSystem firstObject = null;
    
            //Normal crate
            if (particleType == 0)
            {
                //Get the first GameObject
                firstObject = NormalParticle[0];
                //Move everything Up by one
                shiftUp(0);
            }
    
            //TNT crate
            else if (particleType == 1)
            {
                //Get the first GameObject
                firstObject = TNTParticle[0];
                //Move everything Up by one
                shiftUp(1);
            }
    
            return firstObject;
        }
    
        //Returns How much GameObject in the Array
        public int getAmount()
        {
            return particleAmount;
        }
    
        //Moves the GameObject Up by 1 and moves the first one to the last one
        private void shiftUp(int particleType)
        {
            //Get first GameObject
            ParticleSystem firstObject;
    
            //Normal crate
            if (particleType == 0)
            {
                firstObject = NormalParticle[0];
                //Shift the GameObjects Up by 1
                Array.Copy(NormalParticle, 1, NormalParticle, 0, NormalParticle.Length - 1);
    
                //(First one is left out)Now Put first GameObject to the Last one
                NormalParticle[NormalParticle.Length - 1] = firstObject;
            }
    
            //TNT crate
            else if (particleType == 1)
            {
                firstObject = TNTParticle[0];
                //Shift the GameObjects Up by 1
                Array.Copy(TNTParticle, 1, TNTParticle, 0, TNTParticle.Length - 1);
    
                //(First one is left out)Now Put first GameObject to the Last one
                TNTParticle[TNTParticle.Length - 1] = firstObject;
            }
        }
    }
