    ProgressDialog progressDialog = new ProgressDialog();
    Thread backgroundThread = new Thread(
	new ThreadStart(() =>
	{
		try
		{
			psp_grid.DataSource = null;
			psp_grid.Rows.Clear();
			progressDialog.ProgressMax = (int)total;
			progressDialog.Title = "Cargando listado...";
			progressDialog.Status = "Se está cargando el listado de juegos. Por favor espere...";
			progressDialog.Message = "Recuperando juegos de la base de datos";
			using (SQLiteCommand cmd = new SQLiteCommand(query, handle))
			{
				using (SQLiteDataReader rdr = cmd.ExecuteReader())
				{
					while (rdr.Read())
					{
							progressDialog.ProgressActual = Actual;
							progressDialog.Message = "Añadidos " + Actual + " juegos de " + total;
						if (psp_grid.InvokeRequired)
						{
							//MessageBox.Show("Invocando...");
							psp_grid.Invoke(new Action(() => psp_grid.Rows.Add()));
							Int64 _ID = (Int64)rdr["ID"];
							byte[] _ICON0 = (byte[])rdr["ICON0"];
							string _Text = "Hola Primo\n" + rdr["ID"].ToString() + (string)rdr["TITLE"];
							psp_grid.Invoke(new Action(() => psp_grid.Rows[psp_grid.RowCount - 1].Cells[0].Value = _ID));
							psp_grid.Invoke(new Action(() => psp_grid.Rows[psp_grid.RowCount - 1].Cells[1].Value = _ICON0));
							psp_grid.Invoke(new Action(() => psp_grid.Rows[psp_grid.RowCount - 1].Cells[2].Value = _Text));
							switch (int.Parse(rdr["RATE"].ToString()))
							{
								case 1:
									psp_grid.Invoke(new Action(() => psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._1star));
									break;
								case 2:
									psp_grid.Invoke(new Action(() => psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._2star));
									break;
								case 3:
									psp_grid.Invoke(new Action(() => psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._3star));
									break;
								case 4:
									psp_grid.Invoke(new Action(() => psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._4star));
									break;
								case 5:
									psp_grid.Invoke(new Action(() => psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._5star));
									break;
							}
							if (psp_grid.RowCount > 7 && changed == false)
							{
								psp_grid.Invoke(new Action(() => psp_grid.Columns[2].Width = 434));
								changed = true;
							}
						}
						else
						{
							psp_grid.Rows.Add();
							psp_grid.Rows[psp_grid.RowCount - 1].Cells[0].Value = (Int64)rdr["ID"];
							psp_grid.Rows[psp_grid.RowCount - 1].Cells[1].Value = (byte[])rdr["ICON0"];
							psp_grid.Rows[psp_grid.RowCount - 1].Cells[2].Value = "Hola Primo\n" + rdr["ID"].ToString() + (string)rdr["TITLE"];
							switch (int.Parse(rdr["RATE"].ToString()))
							{
								case 1:
									psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._1star;
									break;
								case 2:
									psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._2star;
									break;
								case 3:
									psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._3star;
									break;
								case 4:
									psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._4star;
									break;
								case 5:
									psp_grid.Rows[psp_grid.RowCount - 1].Cells[3].Value = GameStation_Game_Manager.Properties.Resources._5star;
									break;
							}
							if (psp_grid.RowCount > 7 && changed == false)
							{
								psp_grid.Columns[2].Width = 434;
								changed = true;
							}
						}
						Actual++;
					}
				}
			}
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.Write(ex.ToString());
		}
		if (progressDialog.InvokeRequired)
			progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
	}));
