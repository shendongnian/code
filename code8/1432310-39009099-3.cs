    System.Windows.Forms.TextBox[] aosList = new System.Windows.Forms.TextBox[8];
    aosList[0] = txtAsset1;
    aosList[1] = txtAsset2;
    aosList[2] = txtAsset3;
    aosList[3] = txtAsset4;
    aosList[4] = txtAsset5;
    aosList[5] = txtAsset6;
    aosList[6] = txtAsset7;
    aosList[7] = txtAsset8;
    for (int n = 0; n < 8; ++n)
    {
        aosList[n].Text = assets[n].ID; // make sure you have 8 assets also!
    }
