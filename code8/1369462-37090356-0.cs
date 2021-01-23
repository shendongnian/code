        using UnityEngine;
        using System.Collections;
        using UnityEngine.UI;
        
        
        public class BuySkin : MonoBehaviour {
        
        	public int price;
        
        	public void OnClick()
        	{
        		if (BeeCoinScore.coin >= price) {
        
        			BeeCoinScore.coin -= price;
        			Debug.Log ("New skin added");
        		}
        
        		if (BeeCoinScore.coin < price) {
        
        			Debug.Log ("Need more coins!");
        		}
        	}
         }
