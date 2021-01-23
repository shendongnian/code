    foreach (var outermostGroup in data.GroupBy(item => item.Column1))
    {
        var node1 = new System.Web.Ui.WebControls.TreeNode(outermostGroup.Key);
        foreach (var middleGroup in outermostGroup.GroupBy(group => group.Column2))
        {
              var node2 = new System.Web.Ui.WebControls.TreeNode(middleGroup.Key);
              foreach (var innerGroup in middleGroup.GroupBy(group => group.Column3))
              {
                  var node3 = new System.Web.Ui.WebControls.TreeNode(innerGroup.Key);
              }
        }
    }
