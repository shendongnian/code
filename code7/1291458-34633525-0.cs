    delegate void SetSelectedCall(int index, bool option);
    
    private void SetSelectedElement(int index, bool option)
    {
      if (this.listBox1.InvokeRequired)
      { 
        SetSelectedCall d = new SetSelectedCall(SetSelectedElement);
        this.Invoke(d, new object[] { int index, bool option});
      }
      else
      {
        this.listBox1.SetSelected(index,option);
      }
    }
