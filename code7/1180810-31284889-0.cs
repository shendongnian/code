    StringBuilder namevalues = new StringBuilder("");
	for(int i =0; i<2; i++)
	{
		if(namevalues.Length >0 )
		{
            namevalues.Append("*" + Listboxs.Items[i].ToString());
		}
		else
		{
            namevalues.Append(Listboxs.Items[i].ToString());
		}
	}
