    public void SetMemory(int index)
    { 
        if(index >= 0)
        {
    	    PS3.SetMemory(Offsets.WeaponCamo + (0x80 * (uint)camoclassUD.Value) + (0x564 * (uint)camosoldierUD.Value), new byte[] { (0x0A + index)});
        }
    }
