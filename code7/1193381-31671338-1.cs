    private void addNodes()
        {
            try
            {
                TestTreeView.Nodes.Clear();
    
                for (int counter = 1; counter <= 10; counter++)
                {
                    TreeNode[] nodes = TestTreeView.Nodes.Find(counter.ToString(), true);
                    if (nodes.Length == 0)
                    {
                        TestTreeView.Nodes.Add(counter.ToString(), counter.ToString());
                    }
                    else
                    {
                        //node exists
                    }
                }
    
                for (int counter = 5; counter <= 15; counter++)
                {
                    TreeNode[] nodes = TestTreeView.Nodes.Find(counter.ToString(), true);
                    if (nodes.Length == 0)
                    {
                        TestTreeView.Nodes.Add(counter.ToString(), counter.ToString());
                    }
                    else
                    {
                        //node exists
                    }
                }
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An error occurred: ", ex.Message));
            }
    
        }
