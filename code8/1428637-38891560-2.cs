    imagename= myRow["Photo"].ToString();
    imagepath = imagename.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
    for (int j = 0; j <= imagepath.Length-1;j++ )
    { 
        if(imagepath[j]!=null)
        {
            string imagefinals = paths + imagepath[j];
            pics[j].ImageLocation = imagefinals;
            pics[j].SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
    return;
