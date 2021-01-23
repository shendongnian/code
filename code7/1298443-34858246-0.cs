    public Sprite[] myImage; // Its length descried in Inspector and assign sprite images
    public Button myBtn;
    int i=0;
    void Update()
    {
      if(Input.GetMouseButtonDown(0)) // HeresI'm checking condition for Mouse Input,  Change this based on your 
      {    
        if(i+1 < myImage.Length)
        {
         //Make sure it is added in the Inspector.
         myBtn.image.sprite = myImage[i];
         i++;
        }
      }
    }
