    void Start () {
    
        rawImage = gameObject.GetComponent<RawImage> ();
        rawImageRect = rawImage.GetComponent<RectTransform> ();
    
        StartCoroutine(startWebCam());
    
        loadingTextObject.SetActive (false);
        gameObject.SetActive (true);
    
    }
    
    private IEnumerator startWebCam()
    {
        webcamTexture = new WebCamTexture();
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
    
        webcamTexture.Play();
    
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
    
        //Now call GetPixels
        Method();
    
    }
    
    void Method(){
        print (webcamTexture.GetPixels [0]);
    }
