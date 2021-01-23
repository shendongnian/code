	for (int i = Lijst.Count - 1 ; i >= 0 ; i--)
	{
		if (Lijst[i].scanned == false)
		{
			if (Lijst[i].price > (int)nudMinimum.Value)
			{
				Totaal++;
				lblDebug.Text = Totaal.ToString();
			}
			Lijst.RemoveAt(i);
		}
	}
