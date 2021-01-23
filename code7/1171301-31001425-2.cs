    public void InsertSymbol(string symbolSyntax)
    {
    foreach (var obj in Controls)
    {
    	if (obj as AlphaBlendTextBox.AlphaBlendTextBox != null)
    	{
    		var txt = ((AlphaBlendTextBox.AlphaBlendTextBox)obj);
    		var selectionIndex = txt.SelectionStart;
    		int value = int.Parse(symbolSyntax, System.Globalization.NumberStyles.HexNumber);
    		symbolSyntax = char.ConvertFromUtf32(value).ToString();
    		txt.Text = txt.Text.Insert(selectionIndex, symbolSyntax);
    		txt.SelectionStart = selectionIndex + symbolSyntax.Length;
    		break;
    	}
    }
    Invalidate();
    }
    
    public void ApplyColorToSelected()
    {
      int activeLayer = 0;
      foreach (var obj in TheLayers[activeLayer].Graphics.Selection)
      {
    	  obj.Color = LineColor;
      }
      foreach (var obj in Controls)
      {
    	  if (obj as AlphaBlendTextBox.AlphaBlendTextBox != null)
    	  {
    		  ((AlphaBlendTextBox.AlphaBlendTextBox)obj).ForeColor = LineColor;
    	  }
      }
      Invalidate();
    }
