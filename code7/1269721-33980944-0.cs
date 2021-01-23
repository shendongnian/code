    public ConcurrentDictionary<int, double> result = new ConcurrentDictionary<int, double>();
            public  void dft(double[] data)
            {
                int n = data.Length;
                int m = n;// I use m = n / 2d;
                float pi_div = (float)(2.0 * Math.PI / n);
                for (int w = 0; w < m; w++)
                {
                    var w1 = w;
                    Task.Factory.StartNew(() =>
                    {
                        float a = w1*pi_div;
                        float real = 0;
                        float imag=0;
                        for (int t = 0; t < n; t++)
                        {
                            real += (float)(data[t] * Math.Cos(a * t));
                            imag += (float)(data[t] * Math.Sin(a * t)); 
                        }
                        result.TryAdd(w1, (float) (Math.Sqrt(real*real + imag*imag)/n));
                    });
                }
            }      
