    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    public class ShowHidePalettes : MonoBehaviour
    {
    public Button changeColorButton;
    public GameObject colorPalette;
    public Button brushSizeButton;
    public GameObject brushSizePalette;
    private bool colorPalleteVisibility = false;
    private bool brushSizePalleteVisibility = false;
    public void PaletteState(PaleteType type)
    {
        if (type == PaleteType.ColorPalette)
        {
            colorPalleteVisibility = !colorPalleteVisibility;
            colorPalette.SetActive(colorPalleteVisibility);
        }
        else if (type == PaleteType.BrushSizePalette)
        {
            brushSizePalleteVisibility = !brushSizePalleteVisibility;
            colorPalette.SetActive(brushSizePalleteVisibility);
        }
    }
    }
    public enum PaleteType
    {
    ColorPalette, BrushSizePalette
    }
