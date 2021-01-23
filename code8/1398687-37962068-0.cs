	public void SetRowColor()
	{
		try
		{
			for (int i = 0; i < this.dataGridView.Rows.Count; i++)
			{
				if (this.dataGridView.Rows[i].Displayed)
				{
					if (this.dataGridView.Columns.Contains("Interior"))
					{
						if ((int)this.dataGridView.Rows[i].Cells["Interior"].Value == "X")
						{
							this.dataGridView.Rows[i].Cells["Interior"].Style.BackColor = Color.Green;
							this.dataGridView.Rows[i].Cells["Interior"].Style.ForeColor = Color.White;
							this.dataGridView.InvalidateRow(i);
						}
						else
						{
							this.dataGridView.Rows[i].Cells["Interior"].Style.BackColor = Color.White;
							this.dataGridView.Rows[i].Cells["Interior"].Style.ForeColor = Color.Black;
							this.dataGridView.InvalidateRow(i);
						}
					}
				}
			}
		}
	}
