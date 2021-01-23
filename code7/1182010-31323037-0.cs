		private void Form1_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 4; i++)
			{
				tile[i] = new Label();
				tile[i].Height = 200;
				tile[i].Width = 100;
				tile[i].Left = (i % 3) * 100;
				tile[i].Top = i * 200;
				tile[i].BackColor = Color.Black;
				tile[i].Visible = true;
				Controls.Add(tile[i]);
			}
		}
