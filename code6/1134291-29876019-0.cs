    using (MagickImage image = new MagickImage())
    {
      image.Read(@"C:\.....\test1.png");
      image.Evaluate(Channels.Red, EvaluateOperator.Set, Quantum.Max);
      image.Write(@"C:\.....\test2.png");
    }
