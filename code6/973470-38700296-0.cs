    Document doc = this.ActiveUIDocument.Document;
			
	if( !doc.IsFamilyDocument )
	{
		TaskDialog.Show("Error","This is not a family document");
		return;
	}
	//give here old and new name
	string oldname = "Reverse_direction";
	string newname = "Reverse direction";
				
	FamilyManager fman = doc.FamilyManager;
				
	if (fman.get_Parameter(oldname) != null)
	{
		using (Transaction t = new Transaction(doc,"Change name"))
		{
			t.Start();
			FamilyParameter param = fman.get_Parameter(oldname);
			fman.RenameParameter(param, newname);
			t.Commit();
		}
	}
