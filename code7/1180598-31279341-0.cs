    private PictureBox[] pictureBoxArray = new PictureBox[64]; //Initialize array to group picture boxes into picture box array
 
	private void Main_Load(object sender, EventArgs e)
        {
            ConvertGuiPBtoGuiPbArray(ref pictureBoxArray);
        }
	public void ConvertGuiPBtoGuiPbArray(ref PictureBox[] pictureBoxArray)
	{
			int i = 0;
			string NameofPictureBox;
			string PictureBoxNumber;
			foreach (var item in groupBox_DataLayer.Controls)
			{
				if (item is PictureBox)
				{
					NameofPictureBox = ((PictureBox)item).Name;
					PictureBoxNumber = Regex.Match(NameofPictureBox, @"\d+").Value; // \d+ is regex for integers only
					i = Int32.Parse(PictureBoxNumber);  //Convert only number string to int
					i = i - 1;  //bcs of index of array starts from 0-63, not 1-64
					pictureBoxArray[i] = (PictureBox)item; //put PictureBox object in desired position
				}
			}
	}
