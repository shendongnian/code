    int intNumberOfLoops = 1;
    int intLoopCounter = 0;
    int pictureIndex = 0;
    private void startButton_Click(object sender, EventArgs e)
    {
        pictureIndex = 0;
        intLoopCounter = 0;
        // insert error checking here!
        intNumberOfLoops = Convert.ToInt16(mtxtloop.Text);
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        // final image:
        if (intLoopCounter >= intNumberOfLoops)
        {   // this assumes there is a selected item!
            PBox_loop.ImageLocation = listBoxPicturesInAlbum.SelectedItem.ToString();
            timer1.Stop();
            return;
        }
        // the regular loop:
        PBox_loop.ImageLocation = listBoxPicturesInAlbum.Items[pictureIndex];
            
        pictureIndex++;
        if (pictureIndex >= listBoxPicturesInAlbum.Items.Count)
        {
            pictureIndex = 0;
            intLoopCounter++;
        }
    }
