    //possiblilities 1
    foreach (string s in startBlocks)
    {
        Control[] lStarBlock = PnlBoard.Controls.Find(s, true);
        PictureBox startBlock = lStarBlock[0] as PictureBox;
        int sRow = startBlock.Location.Y / tileWidth;
        int sCol = startBlock.Location.X / tileHeight;
        //Rows
        for (int row = sRow; row < sRow + Roll; row++)
        {
            //Columns
            for (int col = sCol; col < sCol + Roll; col++)
            {
                possiblities.Add(String.Format("Col={0:00}-Row={1:00}", col, row));
            }
        }            
    }
