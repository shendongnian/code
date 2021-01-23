    public class BaseForm
    {
    
    	private void SaveButton_Click(System.Object sender, System.EventArgs e)
    	{
    		OnSaveButtonClick();
    	}
    
    
    	protected virtual void OnSaveButtonClick()
    	{
        //Saving process for base form
    	}
    }
    
    public class InheritedForm : BaseForm
    {
    
    
    	protected override void OnSaveButtonClick()
    	{
        //Saving process for inherited form
    	}
    }
