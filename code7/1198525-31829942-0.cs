    private WebCamTexture webcamTexture;
    private Color32[] colors;
    
    private int width = 640;
    private int height = 480;
    
    private Texture2D tex;
    private byte[] bytes;
    
    void Start ()
    {
	WebCamDevice[] devices = WebCamTexture.devices;
	int cameraCount = devices.Length;
	
	if (cameraCount > 0)
	{
		webcamTexture = new WebCamTexture(devices[0].name, width, height);
		webcamTexture.Play();
		colors = new Color32[webcamTexture.width * webcamTexture.height];
		bytes = new byte[colors.Length*3];
		tex = new Texture2D (webcamTexture.width, webcamTexture.height, TextureFormat.RGB24, false);
		gameObject.GetComponent<RawImage> ().texture = tex;
		CvInvoke.CheckLibraryLoaded();
	}
	else {
		Debug.LogError("No Camera found!");
	}
    }
    
    void Update ()
    {
	if (webcamTexture.didUpdateThisFrame) {
		webcamTexture.GetPixels32(colors);
		GCHandle imageHandle = GCHandle.Alloc(colors, GCHandleType.Pinned);
		GCHandle matHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
		using(Image<Bgra, byte> image = new Image<Bgra, byte>(webcamTexture.width, webcamTexture.height, webcamTexture.width * 4, imageHandle.AddrOfPinnedObject())){
			using(Mat mat = new Mat(webcamTexture.height, webcamTexture.width, DepthType.Cv8U, 3, matHandle.AddrOfPinnedObject(), webcamTexture.width*3)){
				CvInvoke.CvtColor(image, mat, ColorConversion.Bgra2Bgr);
			}
		}
		imageHandle.Free();
		matHandle.Free();
		tex.LoadRawTextureData(bytes);
		tex.Apply();
	}
