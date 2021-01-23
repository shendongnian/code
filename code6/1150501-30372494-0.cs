     var checkedItemList = subjectCheckBoxList.Items.Cast<ListItem>().Where(c => c.Selected).ToList();
            List<Model.Subject> list = new List<Model.Subject>();
            foreach (ListItem item in checkedItemList)
            {               
                    Model.Subject aSubject = new Model.Subject();
                    aSubject.ID = int.Parse(item.Value);
                    aSubject.SubjectName = item.Text;
                    list.Add(aSubject);
            }            
            subjectGridView.DataSource = list;  
            subjectGridView.DataBind();
