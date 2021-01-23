    List<string> name = new List<string>();
    name.Add("0.jpg");
    name.Add("1.jpg");
    name.Add("2.jpg");
    name.Add("3.png");
    List<PictureBox> box = new List<PictureBox>();
    box.Add(pictureBox1);
    box.Add(pictureBox2);
    box.Add(pictureBox3);
    box.Add(pictureBox4);
    // 2 lines code for shuffle every kind of IEnumerable
	Random r = new Random();
	name = name.OrderBy(x => r.Next()).ToList();
    ResourceManager rm = MatchGame.Properties.Resources.ResourceManager;
    for (int i = 0; i < box.Count; i++)
    {
    // no need to remove elements from name list
        string randomName = name[i];
        Image img = rm.GetObject(randomName) as Image;
        box[i].Image = img;`
    }
