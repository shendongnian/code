    foreach (var control in pnlButtons.Controls)
    {
        if(control.GetType() == typeof(Button))
        {  
            var button = control as Button;
            if (button .Name.StartWith('btnNum'))
            {
                button.Click += btnNum_Click;
            }
        }
    }
