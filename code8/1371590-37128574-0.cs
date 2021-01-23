    // I think that you are making an buymenu, so you can disable and enable your menu with ui button and check money you have
       
    
         using System.Collections;
            using UnityEngine.UI;
        
            public class BuySkin : MonoBehaviour 
        {
        
                public int price;
                public static int money;// money you have
                public Button thisbuyBee1;
        public void buychkr()
        {
        if(price>= money)
        {
        thisbuyBee1.interactable = false;
        }
        else
        {
        thisbuyBee1.interactable = true;
        }
        }
        void Update()
        {
        buychkr();
        }
    }
    
             
