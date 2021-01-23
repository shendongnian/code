    using UnityEngine;
    using UnityEngine.UI;
    
    {
    	[RequireComponent (typeof(Button))]
    	public class CustomButton : MonoBehaviour
    	{
    
    		void Awake ()
    		{
    			Button btn = GetComponent<Button> ();
    			btn.onClick.AddListener (() => ManagerUI.Instance.onButtonClick (gameObject.name));
    		}
    
    	}
    }
