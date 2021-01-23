        string luaCode = File.ReadAllText(Path.Combine(weaponDataPath, "rifles.Lua"));
        Script script = new Script();        
        script.DoString(luaCode);
        Gun rifle = new Gun();
        Table rifleData = script.Globals["rifles"] as Table;
        for (int i = 1; i < rifleData.Length + 1; i++) {
            Table rifleTable = rifleData.Get(i).Table;
            rifle.Name = rifleTable.Get("Name").String;
            rifle.BaseDamage = (int)rifleTable.Get("BaseDamage").Number;
            rifle.RoundsPerMinute = (int)rifleTable.Get("RoundsPerMinute").Number;
            rifle.MaxAmmoCapacity = (int)rifleTable.Get("MaxAmmoCapacity").Number;
            rifle.Caliber = rifleTable.Get("Caliber").String;
            rifle.WeaponType = "RIFLE";
            RiflePrototypes.Add(rifle.Name, rifle);
        }  
    
