    if (!labelGiveTip1.Visible)
        labelGiveTip1.Visible = true;
    else if(!labelGiveTip2.Visible)
        labelGiveTip2.Visible = true;
    else
    {
        labelGiveTip3.Visible = true;
        Custom_DialogBox.Show("All of your hints for this assignment is used, do you want annother assignmment?", //main text argument
            "Error: No more hints",  //header argument
            "Back",                  //first button text argument
            "Get a new assignment"); //second button text argument
                                     //this is a custom dialog box
    
    
    
        result = Custom_DialogBox.result; 
        switch (result) 
        {
            case DialogResult.Yes:
                {
                    buttonNextAssignment.PerformClick(); 
                    break;
                }
            case DialogResult.Cancel:
                {
                    break; 
                }
            default:
                {
                    break;
                }
        }
    }
