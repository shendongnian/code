    treeView1.Nodes[0].Nodes.Add(new ActionNode("Extended Start",
        () => { MessageBox.Show("Extended Start"); }));
    treeView1.Nodes[1].Nodes.Add(new ActionNode("Hard Reset",
        () => { MessageBox.Show("Hard Reset"); }));
    treeView1.Nodes[2].Nodes.Add(new ActionNode("EOL Mode State Read",
        () => { MessageBox.Show("EOL Mode State Read"); }));
    treeView1.Nodes[2].Nodes.Add(new ActionNode("Current Err Tracer Read",
        () => { MessageBox.Show("Current Err Tracer Read"); }));
    treeView1.Nodes[2].Nodes.Add(new ActionNode("Read Odometer value from Bus Read",
        () => { MessageBox.Show("Read Odometer value from Bus Read"); }));
