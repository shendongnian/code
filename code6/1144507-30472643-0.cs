    private void SetRelation()
    {
        var customPatternView = new GridView(gridControl1);
        customPatternView.Columns.AddField("Name").VisibleIndex = 0;
        customPatternView.Columns.AddField("Description").VisibleIndex = 1;
        this.gridControl1.LevelTree.Nodes.Add("Details2", customPatternView);
        this.gridControl1.ShowOnlyPredefinedDetails = true;
    }
