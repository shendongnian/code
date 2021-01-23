    public void AttachToButton()
    {
    public UnityEvent buttonClicked;
     void Update()
     {
      if (Input.GetButton("Fire1"))
       if (DoPlayerLookAtButton() && isAimationReadyToPlay)
        {
        Debug.Log("Button pressed!");
        if (buttonClicked!=null) buttonClicked.Invoke();
        }
     }
    }
