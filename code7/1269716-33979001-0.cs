    public void UpdatePosition(BaseEventData data)
    {
        var pEventData = data as PointerEventData;
    
        if (pEventData == null)
            return;
     
        //Do whatever with pEventData here
        Debug.Log("UPDATE" + data.GetType());
    }
