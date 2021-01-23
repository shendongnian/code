    // Get the number of CheckBox Controls that are checked
    var checkedBoxes = Form.Controls.OfType<CheckBox>().Count(c => c.Checked);
    // Determine if your specific criteria is met
    if(checkedBoxes > 3)
    {
          // You shall pass!
    }
    else 
    {
          // None shall pass
    }
