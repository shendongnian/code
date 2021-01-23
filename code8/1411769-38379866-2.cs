    if (_positions.Count % 3 == 0)
    {
        // Processing here e.g. ...
        for (int i = 0; i < _positions.Count; i+=3) {
            Vector3 v0 = _positions[i + 0];
            Vector3 v1 = _positions[i + 1];
            Vector3 v2 = _positions[i + 2];
            [...]
        }
    }
    else
    {
        // Flag issue here, either on console or throw an exception...
        Console.WriteLine("Positions array length must be divisible by 3");
    }
