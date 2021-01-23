	BinaryTreeView BinaryTreeViewExample = new BinaryTreeView();
	BinaryTreeViewExample.AddParent("A");
	BinaryTreeViewExample.AddParent("1");
	BinaryTreeViewExample.Add("B", "A");
	BinaryTreeViewExample.Add("C", "A");
	BinaryTreeViewExample.Add("2", "1");
	BinaryTreeViewExample.Add("3", "1");
	BinaryTreeViewExample.Add("D", "1");
	BinaryTreeViewExample.Remove("D");
		
	...Controls.Add(BinaryTreeViewExample);
