    public class Player : MonoBehaviour {
    //Position of mouse since last change in viewdirection
    private float mousePosLast;
    //Tollerance of mouse input 
    //this is optional but makes the the input not that sensitive
    public float mouseTollerance;
    //sets the correct position of mouse on start
    public void Start () {
        mousePosLast = Input.mousePosition.x;
    }
    public void Update () {
        /*
        ...other update code...
        */
        
        if (Input.GetKeyDown(KeyCode.Q)) {
                   Look(currentDirection.GetNextCounterclockwise());
            }
            if (Input.GetKeyDown(KeyCode.E)) {
                Look(currentDirection.GetNextClockwise());
            }
        //check if change in mouse position is big enougth to trigger camera rotation
        if(Mathf.Abs(Input.mousePosition.x - mousePosLast) > mouseTollerance){
            //check whether to turn right or left
            if(Input.mousePosition.x - mousePosLast > 0){
                Look(currentDirection.GetNextCounterclockwise());
            }else{
                Look(currentDirection.GetNextClockwise());
            }
        }
    }
    private void Look (MazeDirection direction) {
            transform.localRotation = direction.ToRotation();
           currentDirection = direction;
    
        //set mousePosLast to current mouseposition on every change -> avoids strange effects
        mousePosLast = Input.mousePosition.x;
    }
}
