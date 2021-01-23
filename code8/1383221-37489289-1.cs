    public class UIDRAGGER : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Canvas parentCanvasOfImageToMove;
    
        //10 UI Buttons (Assign in Editor)
        public Button[] UIButtons;
    
        //2 UI Panels/Images (Assign in Editor)
        public Image[] UIPanels;
    
        //Hold which Button or Image is selected
        private Button selectedButton;
        private Image selectedUIPanels;
    
        //Used to make sure that the UI is position exactly where mouse was clicked intead of the default center of the UI
        Vector3 moveOffset;
    
        //Used to decide which mode we are in. Button Drag or Image/Panel Mode
        private DragType dragType = DragType.NONE;
    
    
        void Start()
        {
            parentCanvasOfImageToMove = gameObject.GetComponent<Canvas>();
        }
    
        //Checks if the Button passed in is in the array
        bool buttonIsAvailableInArray(Button button)
        {
            bool _isAValidButton = false;
            for (int i = 0; i < UIButtons.Length; i++)
            {
                if (UIButtons[i] == button)
                {
                    _isAValidButton = true;
                    break;
                }
            }
            return _isAValidButton;
        }
    
        //Checks if the Panel/Image passed in is in the array
        bool imageIsAvailableInArray(Image image)
        {
            bool _isAValidImage = false;
            for (int i = 0; i < UIPanels.Length; i++)
            {
                if (UIPanels[i] == image)
                {
                    _isAValidImage = true;
                    break;
                }
            }
            return _isAValidImage;
        }
    
        void selectButton(Button button, Vector3 currentPos)
        {
            //check if it is in the image array that is allowed to be moved
            if (buttonIsAvailableInArray(button))
            {
                //Make the image the current selected image
                selectedButton = button;
                dragType = DragType.BUTTONS;
                moveOffset = selectedButton.transform.position - currentPos;
            }
            else
            {
                //Clear the selected Button
                selectedButton = null;
                dragType = DragType.NONE;
            }
        }
    
        void selectImage(Image image, Vector3 currentPos)
        {
            //check if it is in the image array that is allowed to be moved
            if (imageIsAvailableInArray(image))
            {
                //Make the image the current selected image
                selectedUIPanels = image;
                dragType = DragType.IMAGES;
                moveOffset = selectedUIPanels.transform.position - currentPos;
            }
            else
            {
                //Clear the selected Button
                selectedUIPanels = null;
                dragType = DragType.NONE;
            }
        }
    
    
        public void OnBeginDrag(PointerEventData eventData)
        {
            GameObject tempObj = eventData.pointerCurrentRaycast.gameObject;
    
            if (tempObj == null)
            {
                return;
            }
    
            Button tempButton = tempObj.GetComponent<Button>();
            Image tempImage = tempObj.GetComponent<Image>();
            Text tempText = tempObj.GetComponent<Text>();
    
            //For Offeset Position
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvasOfImageToMove.transform as RectTransform, eventData.position, parentCanvasOfImageToMove.worldCamera, out pos);
    
    
            //Button must contain Text then Image and Button as parant
            //Check if this is an image
            if (tempButton == null || tempImage == null)
            {
                //Button not detected. Check if Button's text was detected
                if (tempText != null)
                {
                    //Text detected. Now Look for Button and Image in the text's parent Object
                    tempButton = tempText.GetComponentInParent<Button>();
                    tempImage = tempText.GetComponentInParent<Image>();
    
                    //Since child is text, check if parents are Button and Image
                    if (tempButton != null && tempImage != null)
                    {
                        //This is a Button
                        selectButton(tempButton, parentCanvasOfImageToMove.transform.TransformPoint(pos));
                    }
                    //Check if there is just an image
                    else if (tempImage != null)
                    {
                        //This is an Image
                        selectImage(tempImage, parentCanvasOfImageToMove.transform.TransformPoint(pos));
                    }
                }
                else
                {
                    //This is an Image
                    selectImage(tempImage, parentCanvasOfImageToMove.transform.TransformPoint(pos));
                }
            }
            //Check if there is just an image
            else if (tempImage != null)
            {
                selectImage(tempImage, parentCanvasOfImageToMove.transform.TransformPoint(pos));
            }
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos;
            if (dragType == DragType.BUTTONS)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvasOfImageToMove.transform as RectTransform, eventData.position, parentCanvasOfImageToMove.worldCamera, out pos);
                selectedButton.transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos) + moveOffset;
            }
            else if (dragType == DragType.IMAGES)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvasOfImageToMove.transform as RectTransform, eventData.position, parentCanvasOfImageToMove.worldCamera, out pos);
                selectedUIPanels.transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos) + moveOffset;
            }
        }
    
    
        public void OnEndDrag(PointerEventData eventData)
        {
            //Buttons
            if (dragType == DragType.BUTTONS || dragType == DragType.IMAGES)
            {
                selectedButton = null;
                selectedUIPanels = null;
                dragType = DragType.NONE;
            }
        }
    
        DragType getCurrentDragType()
        {
            return dragType;
        }
    
        private enum DragType { NONE, BUTTONS, IMAGES };
    }
