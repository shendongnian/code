    public class video : MonoBehaviour {
    public MovieTexture movie;
    private AudioSource audio;
    // Use this for initialization
    void Start () {
    }
    // Update is called once per frame
    void Update () {
        GetComponent<RawImage> ().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource> ();
        audio.clip = movie.audioClip;
        movie.Play ();
        audio.Play ();
        if (Input.GetMouseButtonDown(0)){
            RectTransform r = transform.GetComponent<RectTransform>(); //Get's reference to RectTransform
            Vector3 size = new Vector3(r.rect.size.x * r.localScale.x, r.rect.size.y * r.localScale.y, 0); //Size in pixels (scale * default size)
            Vector3 pos = r.localPosition + new Vector3(Screen.width/2f, Screen.height/2f, 0)-size/2; //Position in pixels from the bottom-left corner of Image 
            //(r.localPosition is from the center of screen, that is why I substracted half of
            //the screen and minus half of size of the Image because r.localPosition anchor by default is in the center of Image
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x > pos.x && mousePos.x < pos.x + size.x && mousePos.y > pos.y && mousePos.y < pos.y + size.y) //This is basic logic of testing if point is inside rect
               if(movie.isPlaying) movie.Stop (); else movie.Play (); 
        }
    }
    }
