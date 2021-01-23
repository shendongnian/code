            int x = 2; // your x
            StringBuilder Builtstring = new StringBuilder();
            for (int i = 0; i < tobuild.Length; i++) 
         { 
                string item = tobuild[i];
                Builtstring.Append(item).Append(",");
                if (i%x==0) { Builtstring.Append(item).Append("/"); }
        }
       string built = Builtstring.ToString();
