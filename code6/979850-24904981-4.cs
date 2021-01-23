    private void CreateDynamicControls()
    {
    	int sem = int.Parse(semDropDownList.SelectedItem.Text);
    	string dept = DeptDropDownList.SelectedItem.Text;
    	if (sem != null)
    	{
    		SqlDataReader subject = Mlist.GetSubjects(d_id, sem);
    		int i = 0;
    		while (subject.Read())
    		{
    			sublabels[i] = new Label();
    			subtextbox[i] = new TextBox();
    			sublabels[i].Text = sub;
    			sublabels[i].ID = (subject["SUB_ID"]).ToString();
    			markz[i] = Convert.ToString(subject["SUB_ID"]);
    			subtextbox[i].ID = "subtextbox" + i.ToString();
    			labelPlaceHolder.Controls.Add(sublabels[i]);
    			labelPlaceHolder.Controls.Add(new LiteralControl(""));
    			Textboxholder.Controls.Add(subtextbox[i]);
    			Textboxholder.Controls.Add(new LiteralControl(""));
    			i++;
    
    		}
    
    		subject.Close();
    
    	}
    }
