    bool isScaling = false;
    IEnumerator scaleToFullScreen(GameObject imageToScale, int scaleType, float byTime)
    {
        if (isScaling)
        {
            yield break;
        }
    
        if (scaleType < 0 || scaleType > 2)
        {
            Debug.Log("Invalid ScaleType. Valid Scale Types X:0,  Y:1,  XandY:3");
            yield break;
        }
        isScaling = true;
    
        Canvas canvas = imageToScale.GetComponentInParent<Canvas>();
        float x, y;
    
        if (canvas != null)
        {
            x = canvas.pixelRect.width;
            y = canvas.pixelRect.height;
        }
        else
        {
            x = Screen.width;
            y = Screen.height;
        }
    
        RectTransform rect = imageToScale.GetComponent<RectTransform>();
        if (rect == null)
        {
            rect = imageToScale.AddComponent<RectTransform>();
        }
    
        //Center the position of the image so that it will be resized equally
        rect.anchoredPosition3D = new Vector3(0, 0, rect.anchoredPosition3D.z);
    
    
        //The default Size
        Vector2 originalScale = rect.sizeDelta;
    
        //The new scale we want to scale texture to
        Vector2 newScale = originalScale;
    
        if (scaleType == 0)
        {
            newScale.x = x;
        }
        else if (scaleType == 1)
        {
            newScale.y = y;
        }
        else if (scaleType == 2)
        {
            newScale.x = x;
            newScale.y = y;
        }
    
    
        float counter = 0;
        while (counter < byTime)
        {
            counter += Time.deltaTime;
            rect.sizeDelta = Vector2.Lerp(originalScale, newScale, counter / byTime);
            yield return null;
        }
        isScaling = false;
    }
