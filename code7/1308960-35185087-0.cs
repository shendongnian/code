    private void drawMeButton_Click(object sender, EventArgs e)
    {
        using(EditShape editShape = new EditShape())
        {
            // Here, create a new instance of a Shape and edit it....
            editShape.Shape = new Shape();
            if (editShape.ShowDialog() == DialogResult.OK)
            {
                // Add the new instance to the list, not the same instance
                // declared globally. (and, at this point, useless)
                myShapeList.Add(editShape.Shape);
                panel1.Invalidate();
            }
            // The using blocks makes this call superflous
            // editShape.Dispose();
        }
    }
        
