    public void OnDrag(PointerEventData data){
            Vector2 pos = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle
                (rectTrans,
                data.position,
                data.pressEventCamera,
                out pos))
            {
                rectTrans.anchoredPosition = pos;
            }
    }
