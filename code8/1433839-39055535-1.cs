    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine.UI;
    
    public class ToolButtons : MonoBehaviour
    {
        public Color activeColor;
        public Color inactiveColor;
        public GameObject iconBG;
        public Button ink, brush, crayon, pencil, spray, eraser, chnageColor, brushSize, undo, redo, clear, newAnimal;
        public GameObject inkIconBG, brushIconBG, crayonIconBG, pencilIconBG, sprayIconBG, eraserIconBG, changeColorIconBG, brushSizeIconBG;
    
        Dictionary<Button, GameObject> buttonIconPair = new Dictionary<Button, GameObject>();
    
        void pairButtonIcon()
        {
            buttonIconPair.Add(ink, inkIconBG);
            buttonIconPair.Add(brush, brushIconBG);
            buttonIconPair.Add(crayon, crayonIconBG);
            buttonIconPair.Add(pencil, pencilIconBG);
            buttonIconPair.Add(spray, sprayIconBG);
            buttonIconPair.Add(eraser, eraserIconBG);
            buttonIconPair.Add(chnageColor, changeColorIconBG);
            buttonIconPair.Add(brushSize, brushSizeIconBG);
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
            for (int i = 0; i < buttonIconPair.Count; i++)
            {
                var item = buttonIconPair.ElementAt(i);
                var itemKey = item.Key;
                var itemValue = item.Value;
    
                if (buttonClicked == itemKey)
                {
                    itemValue.GetComponent<Image>().color = activeColor;
                }
                else
                {
                    itemValue.GetComponent<Image>().color = inactiveColor;
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
