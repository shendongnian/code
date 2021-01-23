        using (System.IO.StreamReader sr = new System.IO.StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\sample.txt"))
			{
				while (sr.EndOfStream == false)
				{
					string line = sr.ReadLine();
					string[] columns = line.Split('|');
					try
					{
						//0 1 2     3                                4              5          6          7       8          9          10                11       12       13
						// | |500  |RUBBISH_DEFAULT_COLOR_A         |BOB           |24.09.2010|31.12.9999|       |24.09.2010|10:19:42  |               0 |        |        |
						columns[5] = System.Convert.ToDateTime(columns[5]).ToString("yyyy.MM.dd");
						columns[6] = System.Convert.ToDateTime(columns[6]).ToString("yyyy.MM.dd");
						columns[8] = System.Convert.ToDateTime(columns[8]).ToString("yyyy.MM.dd");
						columns[9] = System.Convert.ToDateTime(columns[9]).ToString("yyyy.MM.dd");
						//any changes can be done to string array before submitting to DB
					}
					catch (FormatException ex)
					{
						// Do something in case of incoorect format.
						MessageBox.Show(ex.Message);
					}
					MessageBox.Show(string.Format("columns[5]:{0}, columns[6]:{1}", columns[5], columns[6]));
				}
			}
