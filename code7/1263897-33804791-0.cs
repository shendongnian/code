     void Start()
    {
        var itemCount = 3;
        for (int i = 0; i < itemCount; i++)
        {
            var x = i; // Important Line
            StartCoroutine(TextureFromURL(() =>
            {
             
                print("i = " + x);
            }));
        }
    }
    IEnumerator TextureFromURL( Action callback)
    {
        yield return null;
        callback();
    }
