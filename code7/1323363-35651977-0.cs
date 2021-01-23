    var radioCheckedList = yourForm.Controls.OfType<RadioButton>().Where(r => r.Checked).ToList(); 
    foreach(var radio in radioCheckedList)
    {
        if (radio.Name == "radio1")
        {
            // display something
        }
        else if (radio.Name == "radio2")
        {
            // display somnething
        }
    }
                      
