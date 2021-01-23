      var hp = new List<double>();
      hp.Add(200);
      hp.Add(150);
      hp.Add(300);
      hp.Add(50);
      var dmg = new List<double>();
      dmg.Add(50);
      dmg.Add(120);
      dmg.Add(240);
      dmg.Add(300);
      var length = hp.Count;
      var timeLists = new List<List<double>>();
      var p1dmg = 50;
      for (int i = 0; i < length; i++)
      {
        var ptime = hp[i] / p1dmg;
        timeLists.Add(new List<double>());
        timeLists[i].Add(dmg.Sum(d => ptime * d));
      }
