    // Create a list of string
    // Add all your 5 textbox values into the list
    // create a boolean variable to check if All textboxes are empty
    // Loop through list
    // If atlist one txtValue is not empty, exit loop and set bool value    to    false
        List<string> txtValues = new List<string>();
        // Add all your 5 textboxes
        txtValues.Add(txtBlock.Text);
        bool allEmpty = true;
        foreach(string txtValue in txtValues){
              if(!string.IsNullOrEmpty(txtValue)){
                    
                    allEmpty=false;
                    // exit for loop
              }
        }
        if(allEmpty){
            // check the txtPlot values
        }
