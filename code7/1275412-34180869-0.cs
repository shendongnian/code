    GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
           string subjectid = editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["SubjectId"].ToString();
           int intSubject = Convert.ToInt16(subjectid);
           var results = from r in DbContext.Subjects.ToList()
                         where r.SubjectId == intSubject
                         select r;
           List<Subject> newSubject = results.ToList();
           //string test = newSubject[0].Comments;
            if (newSubject.Count != 1)
            {
                RadGrid1.Controls.Add(new LiteralControl("Unable to locate the Subject for updating."));
                e.Canceled = true;
                return;
            }
