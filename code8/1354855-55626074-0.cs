    using UnityEngine.UI;
  
 
   
     public class Example : MonoBehaviour
        {
             public UnityEngine.UI.Button Button;
        
        
        public void onClickEvent()
        {
          //make visible
          Button.gameObject.SetActive(true);
        }
}
