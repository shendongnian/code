            int x = 2; // your x
            StringBuilder builtstring = new StringBuilder();
            for (int i = 0; i < tobuild.Length; i++) 
            { 
                string item = tobuild[i];
                builtstring.Append(item).Append(",");
                if (i%x==0) { builtstring.Append("/"); }
            }
            string built = builtstring.ToString();
