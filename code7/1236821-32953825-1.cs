    List<string> selectedPictureBoxes;
    public MyForm()  // ctor
    {
       selectedPictureBoxes = new List<string>();
       foreach(Control c in this.Controls) 
          if(c is PictureBox) c.Click += pictureBox_Click;
    }
    private void pictureBox_Click(object sender, EventArgs e)
    {
        PictureBox _clicked = sender as PictureBox;
        if(!selectedPictureBoxes.Contains(_clicked.Name))
           selectedPictureBoxes.Add(_clicked.Name);
        else ....
    }
