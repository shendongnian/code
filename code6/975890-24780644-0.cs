    var data = new List<TreeItem>
    {
    	new TreeItem { Id = "L1_1", ParentId = "", Text = "ONE" },
    	new TreeItem { Id = "L1_2", ParentId = "", Text = "TWO" },
    	new TreeItem { Id = "L1_3", ParentId = "", Text = "THREE" },
    	new TreeItem { Id = "L2_1", ParentId = "L1_1", Text = "A" },
    	new TreeItem { Id = "L2_2", ParentId = "L1_1", Text = "B" },
    	new TreeItem { Id = "L2_3", ParentId = "L1_2", Text = "C" },
    	new TreeItem { Id = "L2_4", ParentId = "L1_2", Text = "D" },
    	new TreeItem { Id = "L2_5", ParentId = "L1_2", Text = "E" }
    };
    
    tree.Properties.DataSource = data;
    
    }
    
    class TreeItem
    {
    	public string Id { get; set; }
    	public string ParentId { get; set; }
    	public string Text { get; set; }
    }
