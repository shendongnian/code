    public void TakeAction() {        
        // Step 1
        ...do something...
        UpdateUI("Updated Stt 1");
        // Step 2
        ...do something...
        UpdateUI("Updated Stt 2");
        // Step 3
        ...do something...
        UpdateUI("Updated Stt 3");
    }
    void UpdateUI(string message)
    {
        Textbox1.Invoke((MethodInvoker)(() =>
        {
           textbox1.Text= message;
        })); 	
    }
