	private void BindGrid(string parameter)
	{	
		string[] array = parameter.Split();
		string constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\SearchTable.mdf;Integrated Security=True;Connect Timeout=30";
		using (SqlConnection con = new SqlConnection(constring))
		{
			con.Open();
			using (SqlCommand cmd = new SqlCommand("SELECT * FROM Projects", con))
			{
				cmd.CommandType = CommandType.Text;
				using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
				{
					using (DataTable dt = new DataTable())
					{
						sda.Fill(dt);
						List<DataRow> rowsToShow = new List<DataRow>();
						foreach (DataRow row in dt.Rows)
						{
							SqlDataReader reader = cmd.ExecuteReader();
							if (reader.HasRows)
							{
								while (reader.Read())
								{
									int index = reader.GetInt32(0);
									string a = reader.GetString(1);
									string b = reader.GetString(2);
									string c = reader.GetString(3);
									string d = reader.GetString(4);
									string e = reader.GetString(5);
									string f = reader.GetString(6);
									string g = reader.GetString(7);
									string h = reader.GetString(8);
									string i = reader.GetString(9);
									string j = reader.GetString(10);
									string t = a + " " + b + " " + c + " " + d + " " + e + " " + f + " " + g + " " + h + " " + i + " " + j;
									if (array.Any(value => t.IndexOf(value, StringComparison.CurrentCulture) != -1))
									{
										rowsToShow.Add(row);
									}
								}
							}
							reader.Close();
						}
						dataGridView1.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = dt });
						rows = dataGridView1.Items.Count.ToString();
						Rows.Content = rows + " Entries";
					}
				}
			}
			con.Close();
		}
	}
