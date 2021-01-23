    // Weapon types
    public enum F3DFXType
    {
        Vulcan          = 0,
        SoloGun         = 1,
        Sniper          = 2,
        ShotGun         = 3,
        Seeker          = 4,
        RailGun         = 5,
        PlasmaGun       = 6,
        PlasmaBeam      = 7,
        PlasmaBeamHeavy = 8,
        LightningGun    = 9,
        FlameRed        = 10,
        LaserImpulse    = 11,
        MAX_WEAPONS     = 12
    }
    
    
        public bool[] aWeaponsHave = new bool[(int)F3DFXType.MAX_WEAPONS];
        int iWeaponsCurrent;
    
    
    public Constructor() 
    {
    
           .....
         // Start at first weapon (VULCAN)
            iWeaponsCurrent = 0;
            aWeaponsHave[0] = true;
     
            // DEBUG: Add weapon to inventory
            aWeaponsHave[1] = true;
             .....
    }
    
    
    
     private void GoNextWeapon()
        {
            // If there isn't a higher value found, then default back to the original one
            var originalVal = iWeaponsCurrent;
    
            do
            {
                iWeaponsCurrent++;
                // Went to the end of array & didn't find a new weapon. Set it to the original one. 
                if (iWeaponsCurrent == 12)
                {
                    iWeaponsCurrent = originalVal;
                    return;
                }
            } while (aWeaponsHave[iWeaponsCurrent] == false);
        }
    
    
        void GoPrevWeapon()
    {
        do
        {
            iWeaponsCurrent--;
            // Prevent from spilling over
            if (iWeaponsCurrent < 0)
            {
                // Went to end of array. Set weapon to lowest value and get out of here
                iWeaponsCurrent = 0;
                return;
            }
        } while (!aWeaponsHave[iWeaponsCurrent]);
    }
       
    
    
    // Fire turret weapon
        public void Fire()
        {
            switch (iWeaponsCurrent)
            {
                //case F3DFXType.Vulcan:
                case 0:
                    // Fire vulcan at specified rate until canceled
                    timerID = F3DTime.time.AddTimer(0.05f, Vulcan);
                    // Invoke manually before the timer ticked to avoid initial delay
                    Vulcan();
                    break;
                
                //case F3DFXType.SoloGun:
                case 1:
                    timerID = F3DTime.time.AddTimer(0.2f, SoloGun);
                    Debug.Log("Solo");
                    SoloGun();
                    break;
    
                //case F3DFXType.Sniper:
                case 2:
                    timerID = F3DTime.time.AddTimer(0.3f, Sniper);
                    Debug.Log("Sniper");
                    Sniper();
                    break;
               
                //case F3DFXType.ShotGun:
                case 3:
                    timerID = F3DTime.time.AddTimer(0.3f, ShotGun);
                    ShotGun();
                    break;
    
                //case F3DFXType.Seeker:
                case 4:
                    timerID = F3DTime.time.AddTimer(0.2f, Seeker);
                    Seeker();
                    break;
    
                //case F3DFXType.RailGun:
                case 5:
                    timerID = F3DTime.time.AddTimer(0.2f, RailGun);
                    Debug.Log("railgun");
                    RailGun();
                    break;
                //case F3DFXType.PlasmaGun:
                case 6:
                    timerID = F3DTime.time.AddTimer(0.2f, PlasmaGun);
                    PlasmaGun();
                    break;
    
                //case F3DFXType.PlasmaBeam:
                case 7:
                    // Beams has no timer requirement
                    PlasmaBeam();
                    break;
    
                //case F3DFXType.PlasmaBeamHeavy:
                case 8:
                    // Beams has no timer requirement
                    PlasmaBeamHeavy();
                    break;
    
                //case F3DFXType.LightningGun:
                case 9:
                    // Beams has no timer requirement
                    LightningGun();
                    break;
    
                //case F3DFXType.FlameRed:
                case 10:
                    // Flames has no timer requirement
                    FlameRed();
                    break;
    
                //case F3DFXType.LaserImpulse:
                case 11:
                    timerID = F3DTime.time.AddTimer(0.15f, LaserImpulse);
                    LaserImpulse();
                    break;
                default:
                    break;
            }
        }
