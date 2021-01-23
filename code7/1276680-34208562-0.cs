		private async void btnGenerate_Click(object sender, EventArgs e)
		{
			const int totalRuns = 5;
			pbCounter.Visible = true;
			pbCounter.Minimum = 0;
			pbCounter.Maximum = totalRuns;
			pbCounter.Value = 0;
			btnGenerate.Enabled = false;
			
			try
			{
				for ( int i = 1; i <= totalRuns; i++ ) 
				{
					using (var client = new HttpClient()) 
						await client.PostAsync( "endpoint", new StringContent( JsonConvert.SerializeObject( formContent ), Encoding.UTF8, "application/json" ) );
					pbCounter.Value = i;
				}
			}
			catch (Exception ex )
			{
				MessageBox.Show( ex.Message, "Gift Creator", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
			btnGenerate.Enabled = true;
		}
