    public static class TextBoxUtils
    {
    	// internal virtual void SetSelectedTextInternal(string text, bool clearUndo)
    	private static readonly Action<TextBox, string, bool> SetSelectedTextInternal =
    		(Action<TextBox, string, bool>)Delegate.CreateDelegate(typeof(Action<TextBox, string, bool>),
    		typeof(TextBox).GetMethod("SetSelectedTextInternal", BindingFlags.Instance | BindingFlags.NonPublic));
    	public static void UndoableClear(this TextBox target)
    	{
    		if (string.IsNullOrEmpty(target.Text)) return;
    		target.SelectAll();
    		SetSelectedTextInternal(target, string.Empty, false);
    	}
    }
