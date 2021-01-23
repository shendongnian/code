		StringBuilder sb = new StringBuilder();
		foreach (string s in results)
		{
			sb.Append(Environment.NewLine);
			sb.Append(s);
		}
		MessageBox.Show(sb.ToString(), "Results");
