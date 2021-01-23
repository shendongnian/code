    public void updateGUI(string input, RichTextBox guiElement)
    this.Invoke
    (d, new object[] { output, guiElement });
    public void SetText(string output, RichTextBox guiElement)
        {
            guiElement.AppendText(output + "\n");
            guiElement.ScrollToCaret();
            
           
        }
