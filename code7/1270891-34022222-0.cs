    public class MyComboBox : ComboBox
    {
    	protected override bool IsInputKey(Keys keyData)
    	{
    		if (DropDownStyle == ComboBoxStyle.Simple)
    		{
    			switch (keyData & (Keys.KeyCode | Keys.Alt))
    			{
    				case Keys.Return:
    				case Keys.Escape:
    					return false;
    			}
    		}
    		return base.IsInputKey(keyData);
    	}
    }
