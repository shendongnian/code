    void showButton(Button buttonToShow, bool show)
    {
        Image bImage = buttonToShow.GetComponent<Image>();
        Text bText = buttonToShow.GetComponentInChildren<Text>(); //Text is a child of the Button
        if (bImage != null)
        {
            bImage.enabled = show;
        }
        if (bText != null)
        {
            bText.enabled = show;
        }
    }
