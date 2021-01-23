    private void Timer_Tick(object sender, EventArgs e)
    {
        string[] text = GameCode.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
        List<string> movedObjects = new List<string>();
 
        foreach (KeyValuePair<string, Panel> kvp in objects)
        {
            if (running)
            {
                if (text.Contains("Move " + kvp.Key + " Left"))
                {
                    Point loc = kvp.Value.Location;
                    loc.X = loc.X - 1;
                    kvp.Value.Location = loc;
                    movedObjects(kvp.Key); 
                }
                if (text.Contains("Move " + kvp.Key + " Right"))
                {
                    Point loc = kvp.Value.Location;
                    loc.X = loc.X + 1;
                    kvp.Value.Location = loc;
                    movedObjects(kvp.Key);
                }
                if (text.Contains("Move " + kvp.Key + " Up"))
                {
                    Point loc = kvp.Value.Location;
                    loc.Y = loc.Y - 1;
                    kvp.Value.Location = loc;
                    movedObjects(kvp.Key);
                }
                if (text.Contains("Move " + kvp.Key + " Down"))
                {
                    Point loc = kvp.Value.Location;
                    loc.Y = loc.Y + 1;
                    kvp.Value.Location = loc;
                    movedObjects(kvp.Key);
                }
            }
            if(movedObjects.Count() > 1)  // change this logic accordingly when there more than two objects can move.
            {
                 MessageBox.Show("Name1: " + movedObjects[0] + " + Name2: " + movedObjects[1]);
            }          
        }
        //Invalidate();
        DoubleBuffered = false;
    }
