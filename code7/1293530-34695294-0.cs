    List<double> hp = new List<double>(); //items in this list = 4, but it's meant to handle 100's of items
      hp.Add(200);
      hp.Add(150);
      hp.Add(300);
      hp.Add(50);
    List<double> dmg = new List<double>(); //if this list had 100+ objects i'd lose my mind
      dmg.Add(50);
      dmg.Add(120);
      dmg.Add(240);
      dmg.Add(300);
    
    // I consider the length of hp and dmg are both equally long. So hp should contain 100 and dmg as well. Otherwise this loop won't work at all!
    if(hp.Count == dmg.Count) {
        for(int i = 0; i < hp.Count; i++) {
            List<double> timeList = new List<double>();
            var time = hp[i] / dmg[i];  // 200/50 = 4
            timeList.Add(dmg.Sum(d => time * d);      
        }
    }
