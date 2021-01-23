        selectedline = -1;
        for (int i =0; i < LineGroup.Count; i++)
        {
            Pen pen = new Pen(Color.Navy, 8);
            if (LineGroup[i].IsOutlineVisible(Latest, pen))
            {
                selectedline = i;
                break;
    
            }
        }
     
        label1.Text = selectedline.ToString();
        return selectedline;
