    #region stopky
    
            public class Stopky
            {
                [System.Runtime.InteropServices.DllImport("kernel32.dll")]
                private static extern bool QueryPerformanceFrequency(out long frequency);
    
                [System.Runtime.InteropServices.DllImport("kernel32.dll")]
                private static extern bool QueryPerformanceCounter(out long ticks);
    
                protected static double frequency = -1;
    
                public void setStart()
                {
                    QueryPerformanceCounter(out tickStart);
                }
    
                public double getTimeFromStart
                {
                    get
                    {
                        QueryPerformanceCounter(out tickNow);
                        double time = (tickNow - tickStart) / frequency;
                        return time;
                    }
                }
    
                private long tickStart;
                private long tickNow;
    
                public Stopky()
                {
                    if (frequency < 0)
                    {
                        long tmp;
                        QueryPerformanceFrequency(out tmp);
    
                        if (tmp == 0)
                        {
                            throw new NotSupportedException("Error while querying "
                   + "the high-resolution performance counter.");
                        }
    
                        frequency = tmp;
                    }
    
                    setStart();
                }
    
                public void Show()
                {
                    MessageBox.Show(this.getTimeFromStart.ToString());
                }
    
    
            }
    
            #endregion
    
    
    
    
            private void button2_Click(object sender, EventArgs e)
            {
                double[] examples = new double[] { 0, 1, 1.1, 1.51, -0.1, -1, -1.1, -1.51 };
    
                int totalCount = 1500000;
    
                double[] examplesExpanded = new double[totalCount];
    
                for (int i = 0, j = 0; i < examplesExpanded.Length; ++i)
                {
                    examplesExpanded[i] = examples[j];
    
                    if (++j >= examples.Length) { j = 0; }
                }
    
                int[] result1 = new int[totalCount];
                int[] result2 = new int[totalCount];
                int[] result3 = new int[totalCount];
    
                Stopky st = new Stopky();
                for (int i = 0; i < examplesExpanded.Length; ++i)
                {
                    result1[i] = (int)Math.Round(examplesExpanded[i], MidpointRounding.AwayFromZero);
                }
                st.Show();
                st = new Stopky();
                for (int i = 0; i < examplesExpanded.Length; ++i)
                {
                    double val = examplesExpanded[i];
                    if (val >= 0)
                    {
                        result2[i] = (int)Math.Floor(val + 0.5);
                    }
                    result2[i] = (int)Math.Ceiling(val - 0.5);
                }
                st.Show();
                st = new Stopky();
                for (int i = 0; i < examplesExpanded.Length; ++i)
                {
                    double val = examplesExpanded[i];
                    if (val >= 0)
                    {
                        result3[i] = (int)(val + 0.5d);
                    }
                    else
                    {
                        result3[i] = (int)(val - 0.5d);
                    }
                }
                st.Show();
    
                for (int i = 0; i < totalCount; ++i)
                {
                    if(result1[i] != result2[i] || result1[i] != result3[i])
                    {
                        MessageBox.Show("ERROR");
                    }
                }
                MessageBox.Show("OK");
    
            }
