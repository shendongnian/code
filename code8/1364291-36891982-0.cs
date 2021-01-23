    var checkedBoxes = Controls.OfType<CheckBox>().Count(c => c.Checked);
    if(checkedBoxes > 3)
    {
          // You shall pass!
    }
    else 
    {
          // None shall pass
    }
