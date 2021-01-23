    public class m1_btn1_ctrl : MonoBehaviour, IPointerEnterHandler
{
    public GameObject button1;
    Image img;
    
	// Use this for initialization
	void Start ()
    {
        button1 = GameObject.Find("m1_btn1");
        img = button1.GetComponent<Image>();
       
	}
	
	public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Entered");
        img.color = new Color32(0, 255, 255, 255);
	}
