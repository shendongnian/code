    RadMenuItem EditView = new RadMenuItem("Edit/View");
    RadMenuItem Child1 = new RadMenuItem("Child1");
    RadMenuItem Child2 = new RadMenuItem("Child2");
    
    EditView.Items.Add(Child1);
    EditView.Items.Add(Child2);
    
    contextMenu.Items.Add(EditView);
