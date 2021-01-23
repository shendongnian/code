    int nextLeft=30;
    
    foreach (Names name in allNames) 
    {
        Button tempButton = new Button();    
        tempButton.Name = name._id;
        tempButton.Text = name._name;
        tempButton.Location = new System.Drawing.Point(name.positionX + nextLeft,name.positionY);
        listView.Controls.Add(tempButton);
        nextLeft+=30;
    }
