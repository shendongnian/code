            List<double> list = new List<double>();
            list.Add(1);
            list.Add(2.1);
            list.Add(3.5);
            list.Add(4.9);
            list.Add(5);
            double i=2;
            int cnt = 0;
            foreach(var item in list)
            {
                if(i==item || i==(item-0.1))
                {
                    cnt = 1;
                }
            }
            if(cnt<1)
            {
                list.Add(i);
            }
