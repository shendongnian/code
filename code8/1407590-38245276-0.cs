      MobOwner sample = new MobOwner(...);
     
      sample.MobOwner.Add("123");
      sample.MobOwner.Add("456");
      sample.MobOwner.RemoveAt(1);
      sample.MobOwner[0] = "789";
    
      sample.MobOwner = null; // we, usually, don't want such code
