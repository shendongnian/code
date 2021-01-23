    void Start ()
    {
      // if webGL, this will be something like "http://..."
      string assetPath = Application.streamingAssetsPath;
    
      bool isWebGl = assetPath.Contains("://") || 
                       assetPath.Contains(":///");
    
      try
      {
        if (isWebGl)
        {
          StartCoroutine(
            SendRequest(
              Path.Combine(
                assetPath, "myAsset")));
        }
        else // desktop app
        {
          // do whatever you need is app is not WebGL
        }
      }
      catch
      {
        // handle failure
      }
    }
