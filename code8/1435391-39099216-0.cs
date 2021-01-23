    for (int i = 0; i < 5; i++)
    {
    CheckBox chk = new CheckBox();
    chk.Name = "chk" + i.ToString();
    chk.size = new Size(10, 10);
    chk.Top = 10
    chk.Left = 20
    chk.Text = i.ToString();
    chk.CheckedChanged += checkBox_CheckedChanged;    
    group_box_name.controls.Add(chk);
    }
    private void checkBox_CheckedChanged(object sender, System.EventArgs e)
    {
     CheckBox chk=sender as CheckBox;
     if(chk!=null)
     {
        if(chk.Checked)
        {
              string chkName=chk.Name;
              string chkText=chk.Text;
              //your code
        }
     }
    }
