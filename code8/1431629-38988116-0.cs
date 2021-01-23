    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class ShowHidePalettes : MonoBehaviour
    {
        public Button changeColorButton;
        public GameObject colorPalette;
        bool showColorPalette = false;
    
        public Button brushSizeButton;
        public GameObject brushSizePalette;
        bool showSizeButton = false;
    
        void Start()
        {
            colorPalette.SetActive(false);
            brushSizePalette.SetActive(false);
        }
    
        void buttonCallBack(Button buttonClicked)
        {
            //Change Color Palette Button clicked
            if (buttonClicked == changeColorButton)
            {
                showColorPalette = !showColorPalette;//Flip
                colorPalette.SetActive(showColorPalette);
            }
    
            //Change Brush Size Button Button clicked
            if (buttonClicked == brushSizeButton)
            {
                showSizeButton = !showSizeButton;//Flip
                brushSizePalette.SetActive(showSizeButton);
            }
        }
    
        void OnEnable()
        {
            changeColorButton.onClick.AddListener(() => buttonCallBack(changeColorButton));
            brushSizeButton.onClick.AddListener(() => buttonCallBack(brushSizeButton));
        }
    
    
        void OnDisable()
        {
            changeColorButton.onClick.RemoveListener(() => buttonCallBack(changeColorButton));
            brushSizeButton.onClick.RemoveListener(() => buttonCallBack(brushSizeButton));
        }
    }
