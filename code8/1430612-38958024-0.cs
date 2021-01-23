    using UnityEngine ;
    using System.Collections ;
    using UnityEngine.UI ;
    using System ;
    using PaintCraft.Tools ;
    public class BrushWidth : MonoBehaviour
    {
    public Button btn1, btn2, btn3, btn4, btn5, btn6 ;
    public float brushSize ;
    public Text brushNameTextBox ;
    public String brushName ;
    public LineConfig lineConfig ;
    void Awake ()
    {
        lineConfig = gameObject.AddComponent<LineConfig> () ;
        btn1.onClick.AddListener (() => SetThickness (1)) ;
        btn2.onClick.AddListener (() => SetThickness (2)) ;
        btn3.onClick.AddListener (() => SetThickness (3)) ;
        btn4.onClick.AddListener (() => SetThickness (4)) ;
        btn5.onClick.AddListener (() => SetThickness (5)) ;
        btn6.onClick.AddListener (() => SetThickness (6)) ;
    }
    void Start ()
    {
        // Set Starting Thickness
        SetThickness (3) ;
    }
    void SetThickness (int _lineNum)
    {
        switch (_lineNum)
        {
            case 1:
                lineConfig.Scale = 0.1f ;
                brushName = "Thin  " ;
                break ;
            case 2:
                lineConfig.Scale = 0.2f ;
                brushName = "Light  " ;
                break ;
            case 3:
                lineConfig.Scale = 0.35f ;
                brushName = "Regular  " ;
                break ;
            case 4:
                lineConfig.Scale = 0.5f ;
                brushName = "Medium  " ;
                break ;
            case 5:
                lineConfig.Scale = 0.75f ;
                brushName = "Thick  " ;
                break ;
            case 6:
                lineConfig.Scale = 1.0f ;
                brushName = "Heavy  " ;
                break ;
            default:
                break ;
        }
        brushNameTextBox.text = brushName ;
    }
    }
