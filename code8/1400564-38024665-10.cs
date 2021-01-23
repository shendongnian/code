	BinaryTreeView BinaryTreeViewExample = new BinaryTreeView();
	BinaryTreeViewExample.AddParent("A");
	
	BinaryTreeViewExample.Add("D", "A");
	BinaryTreeViewExample.Add("J", "D");
	BinaryTreeViewExample.Add("O", "J");
	BinaryTreeViewExample.Add("N", "J");
	BinaryTreeViewExample.Add("I", "D");
	BinaryTreeViewExample.Add("H", "D");
	
	BinaryTreeViewExample.Add("C", "A");
	BinaryTreeViewExample.Add("G", "C");
	BinaryTreeViewExample.Add("M", "G");
	BinaryTreeViewExample.Add("L", "G");
	
	BinaryTreeViewExample.Add("B", "A");
	BinaryTreeViewExample.Add("F", "B");
	BinaryTreeViewExample.Add("E", "B");
	BinaryTreeViewExample.Add("K", "E");
		
	...Controls.Add(BinaryTreeViewExample);
