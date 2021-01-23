    GammaChanger.GammaRampRgbData originalGamma;
    bool success = GammaChanger.GetCurrentGamma(out originalGamma);
    Console.WriteLine($"Originally: {success}");
    
    success = GammaChanger.SetBrightness(44);
    Console.WriteLine($"Setting: {success}");
    
    Console.ReadLine();
    
    success = GammaChanger.SetGamma(ref originalGamma);
    Console.WriteLine($"Restoring: {success}");
    
    Console.ReadLine();
