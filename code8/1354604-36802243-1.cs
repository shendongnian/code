        public static void CheckAll(this TreeNode Node)
        {
            foreach(TreeNode Child in Node.Nodes)
            {
                if(Child.GetType().Name.In("ChildTablesNode","ChildTableNode"))
                {
                    Child.Checked = Node.Checked;
                    Child.CheckAll();
                }
            }
        }
        private void ctxTree_Opening(object sender, CancelEventArgs e)
        {
            TreeNode nSelected = Tree.SelectedNode;
            ctxScript.Visible = !nSelected.IsAnyOf("TablesNode"
                , "ViewsNode"
                , "ProceduresNode"
                , "UserTableTypesNode"
                , "FunctionsNode"
                , "ServerNode"
                , "DatabaseNode"
                , "ColumnsNode"
                , "ColumnNode"
                , "TriggersNode");
            Type[] x = { typeof(int) };
        }
