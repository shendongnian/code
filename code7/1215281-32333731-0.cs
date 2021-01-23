    public YourMonoBehaviour : MonoBehaviour
    {
      public TextMesh text_tap;
    
      float awakeTime;
    
      void Awake()
      {
        // Remember to activate the GO 3dtext in the scene! 
        text_tap = GameObject.Find("3dtext").GetComponent<TextMesh>():
    
        awakeTime = Time.time
      }
    
    
       void Update()
       {
         if ((Time.time - awakeTime) > 5) 
         {
    
           // second try but it I cant attach my 3d text to my script
           text_tap.gameObject.SetActive(true);
    
         }
    
       }
    }
