    // Be sure to only initialise these only once (or as needed)
    // not every frame.
    //use relative path
    string dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    string filename = dir + @"\image.bmp";
    var _mytext = SharpDX.Direct3D9.Texture.FromFile(device, filename);
    var _sprite = new SharpDX.Direct3D9.Sprite(device);
    
    float posLeft = 10f;
    float posTop = 10f;
    var pos = new SharpDX.Vector3(posLeft, posTop, 0);
    var color = new SharpDX.ColorBGRA(0xffffffff);
    _sprite.Begin(SharpDX.Direct3D9.SpriteFlags.AlphaBlend);
    _sprite.Draw(_myText, color, null, null, pos);
    _sprite.End();
