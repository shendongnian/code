    void Update()
    {
        if (fadingOut)
        {
            // fade out with lerp here
        }
    }
    IEnumerator Pause()
    {
        yield return new WaitForSecondsRealtime(5);
        fadingOut = true;
    }
    void FadeText()
    {
        if (displayInfo == true)
        {
            text1.text = string1;
            text1.color = Color.Lerp(text1.color, Color.white, fadeTime * Time.deltaTime);
        }
        else
        {
            StartCoroutine(Pause());
        }
    }
