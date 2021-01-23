    public void OnPointerUp(PointerEventData eventData){
        Vector3 toSize = PREFABS.instance.fieldSize;
        if(transform.parent == PREFABS.instance.startParent){
            var pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;
     
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);
            if (raycastResults.Count > 0) {
                PREFABS.instance.parentObject = raycastResults[0].gameObject;
            }
     
            if(PREFABS.instance.parentObject.GetComponent<CtrlField>() != null){
                if(PREFABS.instance.parentObject.GetComponent<CtrlField>().isField == false){
                    lastHolder = false;
                    toSize = PREFABS.instance.invSize;
                } else {
                    lastHolder = true;
                }
            } else {
                if(lastHolder == false){
                    toSize = PREFABS.instance.invSize;
                }
            }
        }
     
        LeanTween.scale(itemBeingDragged.GetComponent<RectTransform>(), toSize, 0.2f).setDelay(0f);
    }
