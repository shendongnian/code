	AcroPDDoc pdFrom = new AcroPDDoc();
	AcroPDDoc pdTo = new AcroPDDoc();
	if (pdFrom.Open (fileinfo.FullName))
	{
		if (pdTo.Open(combinedFullPath))
		{
			pdTo.InsertPages(pdTo.GetNumPages() - 1, pdFrom, 0, pdFrom.GetNumPages(), 0);
			pdTo.Save(1, combinedFullPath);
			pdFrom.Close();
			pdTo.Close();
		}
		else
		{
			pdFrom.Close();
			Debug.Write("Failed to open combined pdf to merge with: " + CaseNo);
		}
	}
	}
