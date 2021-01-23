		// Where MyActivePictures < PictureBoxControl , picturename > is the Dictionary
        Dictionary<int, string> MyActivePictures = new Dictionary<int, string>();
      //  i  is your PictureBoxes index as you loop through them
        int i = 0;
        if(box.Count < name.Length){
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
        	if (i > name.Length) // exits the loop in case there are more
        	{
			i = box.Count + 1;
        	}
        }while (i < box.Count);
