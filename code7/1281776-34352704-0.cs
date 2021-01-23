    private void PrintRecursive(TreeNode treeNode, int indentation)
    {
        var indent = new string(' ', indentation * IndentSize);
        // SqlTextNode doesn't have children
        if (treeNode is SqlTextNode)
            Debug.WriteLine(indent + treeNode.Text);
        else
        {
            Debug.WriteLine(indent + "(");
            for (int i=0; i<treeNode.Nodes.Count; i++ )
            { 
                PrintRecursive(treeNode.Nodes[i], indentation+1);
                if (i!=treeNode.Nodes.Count-1)
                {
                    // print the operator
                    indent = new string(' ', (indentation+1) * IndentSize);                
                    Debug.WriteLine(indent + treeNode.Text);
                }
            }
            Debug.WriteLine(indent + ")");
        }
    }
