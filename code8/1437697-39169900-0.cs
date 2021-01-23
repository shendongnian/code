    /// <summary>
    /// Attach this script to any object and assign all (20) images to in images from inspector.
    /// </summary>
    public class ImageContainor : MonoBehaviour
    {
    	/// <summary>
    	/// The List of images to choose from.
    	/// </summary>
    	public List<Image> images = new List<Image>(20);
    
    }
    
    /// <summary>
    /// Attach this script to all the buttons.
    /// </summary>
    public class ButtonClickHandler : MonoBehaviour
    {
    	/// <summary>
    	/// The image containor reference, assign the object on which you have ImageContainor script from inspector.
    	/// </summary>
    	public ImageContainor imageContainor;
    
    
    	/// <summary>
    	/// Register this method as OnClick() Handler from inspector.
    	/// Set index parameter accordingly to enable/disable desired image with this button.
    	/// </summary>
    	/// <param name="index">Index.</param>
    	public void ButtonClick(int index)
    	{
    		for (int i = 0; i < imageContainor.images.Count; i++)
    		{
    			if (i == index)
    			{
    				imageContainor.images[i].enabled == true;
    			}
    			else
    			{
    				imageContainor.images[i].enabled = false;
    			}
    		}
    	}
    
    }
