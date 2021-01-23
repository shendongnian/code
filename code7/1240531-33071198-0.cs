    string s1 = textBox1.Text;
            string s2 = textBox2.Text;            
            float[] Yi;
            Xt = s1.Split(',').Select(s1V => s1V.Trim()).ToArray();
            Yt = s2.Split(',').Select(s2V => s2V.Trim()).ToArray();
            float number;
            if (Xt.Length == Yt.Length)
            {
                int i = 0;
                Xi = new float[Xt.Length];//<---properly initializing the array.
                foreach (var value in Xt)
                {
                    
                    // Console.WriteLine("l:"+Xt.Length+" "+Xt[i]+"+");
                    if (Xt[i] != null)
                    {
                        Xi[i] = float.Parse(Xt[i]);
                    }
                    //  Yi[i] = float.Parse(Yt[i]);
                    i++;
                }
