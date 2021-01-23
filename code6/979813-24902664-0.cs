    //Creating Controls    
    ListBox l1 = new ListBox();
                    l1.Height = 550;
                    l1.Width = 398;
    //Adding Property to controls
                    l1.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    l1.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                    l1.Name = "listBox1";
                    Border bd = new Border();
                    StackPanel sp = new StackPanel();
                    Button btn = new Button();
        
        //Adding Controls to the Containers
                    sp.Childern.Add(btn);
                    bd.Child = sp;
                    l1.Items.Add(sp);
