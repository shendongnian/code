    private void OnGroupEditClick(object sender, EventArgs e)
    {
        if(_treeViewGroups.SelectedNode != null)
        {
            Group grp = _treeViewGroups.SelectedNode.Tag as Group;
            GroupForm groupForm = new GroupForm(grp);
            if (groupForm.ShowDialog() != DialogResult.OK)
                return;
            _treeViewGroups.SelectedNode.Text = groupForm.Group.Name;
        }
    }
