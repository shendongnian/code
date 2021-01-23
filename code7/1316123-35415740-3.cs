    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using System.Collections;
    
    public class Teste:MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    	{
    	public Slider theSlider;
    	public bool sliderIsBeingHeldDown;
    	
    	public void OnPointerDown(PointerEventData data)
    		{
    		sliderIsBeingHeldDown = true;
    		Debug.Log("holding down!");
    		}
    	public void OnPointerUp(PointerEventData data)
    		{
    		sliderIsBeingHeldDown = false;
    		Debug.Log("holding up!");
    		}
    	}
