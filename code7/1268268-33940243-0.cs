    public class MyButton : Button
    {
    	protected override void OnMouseUp(MouseEventArgs mevent)
    	{
    		if (this.IsDisposed) return;
    		base.OnMouseUp(mevent);
    	}
    }
