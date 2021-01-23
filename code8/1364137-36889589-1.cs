    public Button button;
    void Start()
    {
        //Show Button
        showButton(button, true);
    
        //Hide Button
        //showButton(button, false);
    }
    
    void showButton(Button buttonToShow, bool show)
    {
        Image bImage = buttonToShow.GetComponent<Image>();
        Text bText = buttonToShow.GetComponentInChildren<Text>(); //Text is a child of the Button
    
        if (bImage != null)
        {
            Color tempColor = bImage.color;
    
            if (show)
            {
                tempColor.a = 1f; //Show 
                bImage.color = tempColor;
            }
            else
            {
                tempColor.a = 0f; //Hide 
                bImage.color = tempColor;
    
            }
        }
    
        if (bText != null)
        {
            Color tempColor = bText.color;
    
            if (show)
            {
                tempColor.a = 1f; //Show 
                bText.color = tempColor;
            }
            else
            {
                tempColor.a = 0f; //Hide 
                bText.color = tempColor;
    
            }
        }
    }
