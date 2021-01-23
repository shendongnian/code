		// Where MyActivePictures < PictureBoxControl , picturename > is the Dictionary
        Dictionary<int, string> MyActivePictures = new Dictionary<int, string>();
      //  i  is your PictureBoxes index as you loop through them
        int i = 0;
        do
        {
        	int randomPic = new Random().Next(0, name.Count);
        	string randomName = name[randomPic];
        	if(!MyActivePictures.Values.Contains[randomName])
        	{
        		name.Remove(randomName);
        		Image img = rm.GetObject(randomName) as Image;
        		box[i].Image = img;
        		MyActivePictures[i]=randomName;
        
        		i++;
        	}
        }while (i < box.Count);
