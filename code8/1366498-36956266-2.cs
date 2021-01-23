    public IEnumerator GenerateItems()
    {
        int i = 0;
        foreach (ArrayList eat in eatArray)
        {
            Debug.Log(i);
    
    
            GameObject localItem = (GameObject)Instantiate(item, Vector3.zero, Quaternion.identity);
    
    
            localItem.GetComponent<Button>().onClick.AddListener(() => buttonCallBack(i));
            localItem.transform.SetParent(grid.transform);
            localItem.transform.localScale = autoLocalScale;
            localItem.transform.localPosition = Vector3.zero;
    
            i++;
    
        }
        yield return new WaitForSeconds(.1f);
    
    
    
    
        ///1. Two ways to move the scroll to first item
        scrollRect.horizontalNormalizedPosition = 0;
    
        //      //2. Moving the scroll bar to left
        //      //scrollBar.value = 0;
    
    }
    
    void buttonCallBack(int buttonIndex)
    {
        //Button Index 0
        if (buttonIndex == 0)
        {
            Debug.Log("Button: " + buttonIndex + "PRESSED");
        }
    
        //Button Index 1
        if (buttonIndex == 1)
        {
    
        }
    }
