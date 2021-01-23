    protected void Button1_Click(object sender, EventArgs e)
        {
            List<DropDownList> lst = new List<DropDownList>();
            GetDropDownControls(GetListOfConrolCollection(this.Form.Controls), ref lst);
            foreach (DropDownList item in lst)
            {
                var selectedValue = item.SelectedValue;
                //to do something with value
            }
        }
            void GetDropDownControls(List<Control> controls, ref List<DropDownList> lst)
        {
            foreach (Control item in controls)
            {
                if (item.Controls.Count == 0 && item is DropDownList)
                    lst.Add((DropDownList)item);
                else
                    if (item.Controls.Count > 0)
                        GetDropDownControls(GetListOfConrolCollection(item.Controls), ref lst);
            }
        }
        List<Control> GetListOfConrolCollection(ControlCollection controls)
        {
            List<Control> result = new List<Control>();
            foreach (Control item in controls)
            {
                result.Add(item);
            }
            return result;
        }
