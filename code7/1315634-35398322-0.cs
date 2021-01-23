    private void OnGroupEditClick(object sender, EventArgs e)
    {
        if(_treeViewGroups.SelectedNode != null)
        {
            GroupForm groupForm = new GroupForm();
            if (groupForm.ShowDialog() != DialogResult.OK)
                return;
        
            Group grp = _treeViewGroups.SelectedNode.Tag as Group;
            if(grp != null)
            {
                grp.Name = groupForm.Group.Name;
                _treeViewGroups.SelectedNode.Text = groupForm.Group.Name;
            }
        }
    }
