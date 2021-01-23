    void highlightDuplicates(int i) // i is the index of the box that was changed
    {
       int iVal = textBoxes[i].Text;
       for (int j = 0; j < 82; j++) 
       {
          // don't compare to self
          if (i == j) return;
    
          if (textBoxes[j].Text == iVal)
          {
             textBoxes[i].BackgroundColor = System.Drawing.Color.Red;
             textBoxes[j].BackgroundColor = System.Drawing.Color.Red;
          }
       }
    }
