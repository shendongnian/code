    // The setup routine that is the one place in your system that knows how to do this task
    public void SetUpPictureBox(ControlCollection collectionParent, PictureBox pictureBox) {
       collectionParent.Add(pictureBox);
       pictureBox.BackColor = Color.Transparent;
    }
    
    // All your picture boxes that are important to you for whatever reason
    // can now be worked with as a unit.
    List<PictureBox> importantPictureBoxes = new list<PictureBox> { pb1, pb2, pb3, pb4 };
    // Set up all the important PBs.
    importantPictureBoxes.ForEach(pb => SetupPictureBox(pbBordermain.Controls, pb));
