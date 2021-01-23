        List<PictureBox> myPictureBoxes;
        int index;
        public void iniPictureBoxes()
        {
            myPictureBoxes = new List<PictureBox>();
            myPictureBoxes.Add(pictureBox1);
            myPictureBoxes.Add(pictureBox2);
            index = 0;
        }
        public void changePictureBox(Keys keyData)
        {
            myPictureBoxes[index].BorderStyle = BorderStyle.None;
            if(keyData == Keys.Right)
            {
                if(index < myPictureBoxes.Count - 1)
                    index++;
            }
            else if(keyData == Keys.Left)
            {
                if(index>0)
                    index--;
            }
            myPictureBoxes[index].BorderStyle = BorderStyle.FixedSingle;
        }
