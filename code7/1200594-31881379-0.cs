    private void button1_Click(object sender, EventArgs e)
            {
                string textToCopy = "";
                foreach (var control in this.Controls) {
                    var label =  control as Label;
                    if (label !=null) {
                        textToCopy += label.Text;
                    }
                
                }
    
                Clipboard.SetText(textToCopy);
            }
