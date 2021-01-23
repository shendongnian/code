     private void arrButton_Click(object sender, EventArgs e)
     {
         var button = sender as Button;
         var indeces = (Indeces) button.Tag;//get indeces here
         var i = indeces.IndexI;
         var j = indeces.IndexJ;
     }
