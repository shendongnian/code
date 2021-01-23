      //same as OP
      public Complex[] CrossCorrelation(Complex[] ffta, Complex[] fftb)
      {
        var conj = ffta.Select(i => new Complex(i.Re, -i.Im)).ToArray();
        conj = conj.Zip(fftb, (v1, v2) => Complex.Multiply(v1, v2)).ToArray();
        FourierTransform.FFT(conj, FourierTransform.Direction.Backward);
        //get that data and plot in Excel, to show the max peak 
        Console.WriteLine("---------rr[i]---------");
        double[] rr = new double[conj.Length];
        rr = conj.Select(i => i.Magnitude).ToArray();
        for (int i = 0; i < conj.Length; i++)
            Console.WriteLine(rr[i]);
        Console.WriteLine("----end-----");
        return conj;
      }	
	
     //tuble.Item1: Cor. Coefficient
	 //tuble.Item2: Delay of signal (Lag)
     public Tuple<double, int> CorrelationCoefficient(Complex[] ffta, Complex[] fftb)
    {
        Tuple<double, int> tuble;
        var correlation = CrossCorrelation(ffta, fftb);
        var seq = correlation.Select(i => i.Magnitude);
        var maxCoeff = seq.Max();
        int maxIndex = seq.ToList().IndexOf(maxCoeff);
        Console.WriteLine("max: {0}", maxIndex);
        tuble = new Tuple<double, int>(maxCoeff, maxIndex);
        return tuble;
    }
      // Pad signal with zeros up to 2^n and convert to complex 
      public List<Complex> ToComplexWithPadding(List<double> sample, int padding = 1)
        {
            //As per AForge documentation:
            //    The method accepts data array of 2n size only, where n may vary in the [1, 14] range
            //So you would need to make sure the input size is correctly padded to a length that is a power of 2, and in the specified range:
            double logLength = Math.Ceiling(Math.Log(sample.Count * padding, 2.0));
            int paddedLength = (int)Math.Pow(2.0, Math.Min(Math.Max(1.0, logLength), 14.0));
            Complex[] complex = new Complex[paddedLength];
            var samples = sample.ToArray();
            // copy all input samples
            int i = 0;
            for (; i < sample.Count; i++)
            {
                complex[i] = new Complex(samples[i], 0);
                Console.WriteLine(complex[i].Re);
            }
            // pad with zeros
            for (; i < paddedLength; i++)
            {
                complex[i] = new Complex(0, 0);
                Console.WriteLine(complex[i].Re);
            }
            return complex.ToList();
           
        }
        // extra for signal generation for testing. You can find in the link of the life demo.
