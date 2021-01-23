    // Display message box
    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
    // Process message box results 
    switch (result)
    {
        case MessageBoxResult.Yes:
            // User pressed Yes button 
            // ... 
            break;
        case MessageBoxResult.No:
            // User pressed No button 
            // ... 
            break;
        case MessageBoxResult.Cancel:
            // User pressed Cancel button 
            // ... 
            break;
     } 
