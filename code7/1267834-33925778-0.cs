	private void button1_Click(object sender, EventArgs e)
	{
		Uri fileURI = new Uri(URLbox.Text);
		WebRequest request = WebRequest.Create(fileURI);
		HttpWebResponse response = null;
		request.Method = "HEAD";
		bool exists = false;
		try
		{
			response = (HttpWebResponse)request.GetResponse();
			exists = response.StatusCode == HttpStatusCode.OK;
		}
		catch
		{
			exists = false;
		}
		finally
		{
			if (response != null)
				response.Close();
		}
		if(exists)
		{
			label1.Text = "Active";
		}
	}
