    int top = 0;
    for (int i = 0; i < 5; i++)
    {
       CheckBox chk = new CheckBox();
       chk.size = new Size(10, 10);
       chk.Top += (5 + 10); //Spacing = 5, CheckboxHeight = 10
       chk.Left = 20;
       chk.Text = i.ToString();
       chk.CheckedChanged += CheckBox_CheckedChanged;
       chk.Tag = i;/*You can put anything here. 
                     Otherwise you could also use the Name property.. 
                     It just helps to determine which checkbox was currently checked */    
       group_box_name.controls.Add(chk);
    }
    private void checkBox_CheckedChanged(object sender, System.EventArgs e)
    {
       CheckBox cbx = (CheckBox)sender;
       if(cbx != null)
       {
          int tag = int.Parse(cbx.Tag.ToString());
          switch(tag)
          {
             case 0:
             //Do whatever:
             break;
             
             //Handle other cases here:
          }
       }
    }
