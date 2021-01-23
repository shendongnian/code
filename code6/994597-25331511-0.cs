    protected void Page_Load(object sender, EventArgs e)
    {
         Response.Write("Previous Node ::: " + ViewState["PreviousNode"] + "<br/>");
         if (treeView1.SelectedNode != null)
         {
               Response.Write("Current Node :::" + treeView1.SelectedNode.Text.ToString());
         }
    }
    
    protected void treeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
         ViewState["PreviousNode"] = treeView1.SelectedNode.Text.ToString();
    
    }
