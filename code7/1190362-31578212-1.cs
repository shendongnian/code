        for (int i = 0; i < 100 ; i++)
        {
            for (int j=0 ; j< 100; i++)
            {
                arrButton[i, j] = new Button();
                arrButton[i,j].Size = new Size(size1button, size1button);
                arrButton[i,j].Location = new Point(j*size1button, i*size1button);
                arrButton.Click += new EventHandler(arrButton_Click);
                arrButton.Tag = new Indeces {IndexI = i,IndexJ = j};
            }
        }
  
     private void arrButton_Click(object sender, EventArgs e)
     {
         var button = sender as Button;
         var indeces = (Indeces) button.Tag;//get indeces here
         var i = indeces.IndexI;
         var j = indeces.IndexJ;
     }
