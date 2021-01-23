    public class DoorOpen : MonoBehaviour
    {
    //this variable will decide wether door is open or not, its initially on false because the door is closed.
    bool isDoorOpen = false;
    bool canOpenDoor = false;
    //this variable will play the audio when the door opens
    public AudioSource sound01;
    void Start()
    {
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bathroom_Door")
        {
             canOpenDoor = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Bathroom_Door")
        {
             canOpenDoor = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
         if (canOpenDoor && Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Animation>().Play("DoorO");
            sound01.Play();
            //this variable becomes true because the door is open
            isDoorOpen = true;
        }
    }
    }
