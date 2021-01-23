    bool isAnyRadioButtonChecked = false;
    foreach (RadioButton rdo in gbRadioButtons.Controls.OfType<RadioButton>())
    {
        if (rdo.Checked)
        {
            isAnyRadioButtonChecked=true;
            break;
        }
    }
    if (isAnyRadioButtonChecked)
    { 
      // Code here one button is checked
    }
    else
    {
      // Print message no button is selected 
    }
