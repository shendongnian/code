     List<List<float>> Order = new List<List<float>>();
            //List<float> SubList = new List<float>();
            List<float> Conditions = new List<float>();
            string tmp;
            string[] levels;
            string[] sublevels;
            float curlevel;
            tmp = "1,2,3;1,3,2;2,1,3;2,3,1;3,1,2;3,2,1";
            levels = tmp.Split(';');
            for (int i = 0; i < levels.Length; i++)
            {
                List<float> SubList = new List<float>();
                sublevels = levels[i].Split(',');
                for (int a = 0; a < sublevels.Length; a++)
                {
                    float.TryParse(sublevels[a], out curlevel);
                    SubList.Add(curlevel);
                }
                Order.Add(SubList);
                //SubList.Clear();
            }
            foreach (float cond in Order[3])
            {
                Conditions.Add(cond);
            }
