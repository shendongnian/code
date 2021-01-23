    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class HoverText : MonoBehaviour
    {
    	Text text;
    	public string content = "Text A";
    	public string contentHighlighted = "▶ Text A";
    
    	void Awake()
    	{
    		text = GetComponent<Text>();
            text.text = content;
    	}
    
    	public void Highlight()
    	{
    		text.text = contentHighlighted;
    	}
    
    	public void UnHighlight()
    	{
    		text.text = content;
    	}
    }
