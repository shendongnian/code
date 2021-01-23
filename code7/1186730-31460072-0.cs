    public async void processbutton(object sender, EventArgs e)
    {
		pictureBox1.Visible = true;
		Image image=Image.FromFile("C:\\Users\\me\\Documents\\Curr\\Projects\\Proj\\Proj\\load.gif");
		pictureBox1.Image = image;
		//--------------------------------------------------------------------------
		await Task.Run(() =>
		{
			string ssqlconnectionstring = "string";
			SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
			string comm = "SELECT * from Table";
			sqlconn.Open();
			//---------------------REST OF CODE-------------------------			
		});
