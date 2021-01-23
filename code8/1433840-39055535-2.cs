    public class ToolButtons : MonoBehaviour
    {
        public Color activeColor;
        public Color inactiveColor;
        public GameObject iconBG;
        public Button ink, brush, crayon, pencil, spray, eraser, chnageColor, brushSize, undo, redo, clear, newAnimal;
        public GameObject inkIconBG, brushIconBG, crayonIconBG, pencilIconBG, sprayIconBG, eraserIconBG, changeColorIconBG, brushSizeIconBG;
    
        List<Button> button = new List<Button>();
        List<GameObject> iconGameObjects = new List<GameObject>();
    
        void pairButtonIcon()
        {
            button.Add(ink);
            iconGameObjects.Add(inkIconBG);
    
            button.Add(brush);
            iconGameObjects.Add(brushIconBG);
    
            button.Add(crayon);
            iconGameObjects.Add(crayonIconBG);
    
            button.Add(pencil);
            iconGameObjects.Add(pencilIconBG);
    
            button.Add(spray);
            iconGameObjects.Add(sprayIconBG);
    
            button.Add(eraser);
            iconGameObjects.Add(eraserIconBG);
    
            button.Add(chnageColor);
            iconGameObjects.Add(changeColorIconBG);
    
            button.Add(brushSize);
            iconGameObjects.Add(brushSizeIconBG);
        }
    
        void Start()
        {
            pairButtonIcon();
            inactiveColor = iconBG.GetComponent<Image>().color;
        }
    
        // Use this for initialization
        void buttonCallBack(Button buttonClicked)
        {
    
            //My Code
            for (int i = 0; i < button.Count; i++)
            {
                if (buttonClicked == button[i])
                {
                    iconGameObjects[i].GetComponent<Image>().color = activeColor;
                }
                else
                {
                    iconGameObjects[i].GetComponent<Image>().color = inactiveColor;
                }
            }
        }
    
        void OnEnable()
        {
            ink.onClick.AddListener(() => buttonCallBack(ink));
            brush.onClick.AddListener(() => buttonCallBack(brush));
            crayon.onClick.AddListener(() => buttonCallBack(crayon));
            pencil.onClick.AddListener(() => buttonCallBack(pencil));
            spray.onClick.AddListener(() => buttonCallBack(spray));
            eraser.onClick.AddListener(() => buttonCallBack(eraser));
        }
    
    
        void OnDisable()
        {
    
        }
    }
