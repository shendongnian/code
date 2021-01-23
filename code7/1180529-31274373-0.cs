    var path = "MyApplicationNamespace.Content.dj.wav";
    var assembly = Assembly.GetExecutingAssembly();
    using( var soundStream = assembly.GetManifestResourceStream( path ) )
    using( var soundPlayer = new SoundPlayer( soundStream ) )
    {
        soundPlayer.Play();
    }
