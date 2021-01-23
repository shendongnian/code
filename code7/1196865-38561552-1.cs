    public void yourMethod()
    {
       StartCoroutine(setImage("http://url/image.jpg")); //balanced parens CAS
    }
    IEnumerator setImage(string url) {
        Texture2D texture = profileImage.canvasRenderer.GetMaterial().mainTexture as Texture2D;
        WWW www = new WWW(url);
        yield return www;
        // calling this function with StartCoroutine solves the problem
        Debug.Log("Why on earh is this never called?");
        www.LoadImageIntoTexture(texture);
        www.Dispose();
        www = null;
    }
