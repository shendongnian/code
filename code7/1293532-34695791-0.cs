            List<double> hp = new List<double>();
            hp.Add(200);
            hp.Add(150);
            hp.Add(300);
            hp.Add(50);
            List<double> dmg = new List<double>();
            dmg.Add(50);
            dmg.Add(120);
            dmg.Add(240);
            dmg.Add(300);
            List<double> timeList = new List<double>();
           
            var p1dmg = 50;
            for (int i = 0; i < hp.Count; i++)
            {
                double sum = Enumerable.Sum(dmg.Select(d => d * (hp[i] / p1dmg)));
                timeList.Add(sum);
               
            }
