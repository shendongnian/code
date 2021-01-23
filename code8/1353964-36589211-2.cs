    public class GameManager : MonoBehaviour {
    Basket bask;
    public Text text_apple; 
    // Use this for initialization
    void Start () {
        bask = GameObject.Find("BaskNameInHierarchy").GetComponent<Basket>()
        text_apple.text = bask.displayApple; //i want to call the method of displayApple to get the string returned.
        }
    }
