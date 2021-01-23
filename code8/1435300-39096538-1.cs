     public Text example;
     public Color newColor;
     public float fadeTime = 0.1f; //maybe rename this to fadeSpeed
     //this should be called somewhere in Update
     void FadeOut()
     {
        example.color = Color.Lerp(example.color, newColor, fadeTime * Time.deltaTime);
     }
