	List<PictureBox> box = new List<PictureBox>();
	box.AddRange(new PictureBox[]
	{
		pictureBox1,
		pictureBox2,
		pictureBox3,
		pictureBox4,
		pictureBox5,
		pictureBox6,
	});
	List<string> name = new List<string>()
	{
		"_1.jpg",
		"_2.jpg",
		"_3.jpg",
		"_4.jpg",
		"_5.jpg",
		"_6.jpg"
	};
	Random r = new Random();
	for (int i = 0; i < this.Count; i++)
	{
        var rm = new System.Resources.ResourceManager(((System.Reflection.Assembly)System.Reflection.Assembly.GetExecutingAssembly()).GetName().Name + ".Properties.Resources", ((System.Reflection.Assembly)System.Reflection.Assembly.GetExecutingAssembly()));
        this[i].Image = (Bitmap)rm.GetObject(name[r.Next(0, 6)]);
	}
