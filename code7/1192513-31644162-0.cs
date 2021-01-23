    public int childCount;
    public void countChildren() 
    {
        GameObject buildBoard = GameObject.FindGameObjectWithTag("Board");
    
        childCount = buildBoard.transform.Cast<Transform>().Count(t => t.gameObject);
    
        Debug.Log(childCount);
    }
