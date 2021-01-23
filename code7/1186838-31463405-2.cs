    protected void Page_Load(object sender, EventArgs e)
    {
       FindValue(this);
    }
    private void FindValue(Control ctrls)
    {
         foreach (Control c in ctrls.Controls)
         {
             if (c is CheckBoxList)
             {
                    CheckBoxList ff = c as CheckBoxList;
                    for (int i = 0; i < ff.Items.Count; i++)
                    {
                        if ((string)ff.Items[i].Value == "43")
                        {
                            //Do Something
                        }
                    }
              }
             else FindValue(c);
         }
    }
