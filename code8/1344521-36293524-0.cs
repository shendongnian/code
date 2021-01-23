        sin = new float[44100];
        for ( var i = 0; i < 44100; ++i)
        {
            sin[i] = Mathf.Sin(i/100);
        }
    
        var bandpass = new BandpassFilter(44100, 440); 
    
        for (  i = 0; i < 44100; ++i)
        {
            sin[i] = bandpass.Process(sin[i] );
        }
