    private void RefreshWindowsList()
        {
            ...   
            for (int i = listBoxSnap.Items.Count - 1; i >= 0; i--)
            {
                string tt = listBoxSnap.Items[i].ToString();
                if (tt.Contains(" ,"))
                {
                    listBoxSnap.Items.RemoveAt(i);
                }
            }
    //add here ->
            string[] myList = new string[listBoxSnap.Items.Count];
            for (int i = 0; i < listBoxSnap.Items.Count; i++)
            {
                string tt = listBoxSnap.Items[i].ToString();
                int index = tt.LastIndexOf(",");
                myList [i] = tt.Substring(0, index);
            }
            listBox1.Items.AddRange(myList);
            
            rectangles = new Rectangle[listBoxSnap.Items.Count];
            isCropped = new bool[listBoxSnap.Items.Count];
            textBoxIndex.Text = listBoxSnap.Items.Count.ToString();
            if (this.listBoxSnap.Items.Count > 0)
            {
                this.listBoxSnap.SetSelected(0, true);
                this.listBox1.SetSelected(0, true);
            }
            listBoxSnap.Select();
            listBox1.Select();
        }
