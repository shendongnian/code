    public class cs_SliderClick : MonoBehaviour {
    
         public int sliderValue;
    
         void Start () 
         {
    
         }
    
         void Update () 
         {
             OnMouseDown();
         }
    
         public void OnMouseDown()
         {
             if (Input.GetMouseButtonDown(0))
             {
                 sliderValue += 1;
             }
    
             if (Input.GetMouseButtonDown(1))
             {
                 sliderValue -= 1;
             }
         }
     }
