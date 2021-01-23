    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace YourNamespace
    {
    	public class NonSelectableButton : Button
    	{
    		public NonSelectableButton()
    		{
    			SetStyle(ControlStyles.Selectable, false);
    		}
    	}
    }
