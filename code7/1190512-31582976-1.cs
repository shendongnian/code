            treeView1.BeginUpdate();
            try
            {
                var nodes = items
                    .GroupBy(_ => string.Format("{0}.{1}", _.SchemaName, _.TableName))
                    .Select(_ => new TreeNode(
                        _.Key,
                        _.Select(info => new TreeNode(info.ColumnName)
                        {
                            Tag = info
                        })
                        .ToArray()))
                    .ToArray();
                treeView1.Nodes.AddRange(nodes);
            }
            finally
            {
                treeView1.EndUpdate();
            }
