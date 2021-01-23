    public Canvas parentCanvasOfImageToMove;
    public Image imageToMove; 
    public void Update()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvasOfImageToMove.transform as RectTransform, Input.mousePosition, parentCanvasOfImageToMove.worldCamera, out pos);
        imageToMove.transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos);
    }
