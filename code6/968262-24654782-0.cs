    public FormField AddTextField(string inRect, string inName, string inText)
    {
    	bool fieldAlreadyExists = mDoc.Form[inName] != null;
    
    	int fieldId = mDoc.AddObject("<</Type /Annot /Subtype /Widget /F 4 /FT /Tx /Ff 4096 /Q 1>>");
    	mDoc.SetInfo(fieldId, "/V:Text", inText);
    	RegisterField(fieldId, inName, inRect);
    	var field = new FormField(fieldId, mDoc);
    
    	if (fieldAlreadyExists)
    	{
    		InteractiveForm form = new InteractiveForm(mDoc);
    		form.AddFieldIntoExistingGroup(field, true);
    	}
    
    	return field;
    }
    
    
    private bool AddFieldIntoExistingGroup(FormField field, bool refreshForm)
    {
    	bool duplicatesFound = false;
    	int acroFormID = mDoc.GetInfoInt(mDoc.Root, "/AcroForm:Ref");
    	int parentID = mDoc.GetInfoInt(field.Id, "/Parent:Ref");
    	ArrayAtom kids;
    	if (parentID > 0)
    	{
    		kids = mDoc.ObjectSoup.Catalog.Resolve(Atom.GetItem(mDoc.ObjectSoup[parentID].Atom, "Kids")) as ArrayAtom;
    	}
    	else
    	{
    		kids = mDoc.ObjectSoup.Catalog.Resolve(Atom.GetItem(mDoc.ObjectSoup[acroFormID].Atom, "Fields")) as ArrayAtom;
    	}
    	Dictionary<string, List<IndirectObject>> items = new Dictionary<string, List<IndirectObject>>();
    	for (int i = 0; i < kids.Count; i++)
    	{
    		IndirectObject io = mDoc.ObjectSoup.Catalog.ResolveObj(kids[i]);
    		if (io == null)
    		{
    			continue; // shouldn't really happen
    		}
    		string name = mDoc.GetInfo(io.ID, "/T:Text");
    		if (!items.ContainsKey(name))
    		{
    			items[name] = new List<IndirectObject>();
    		}
    		items[name].Add(io);
    	}
    	foreach (KeyValuePair<string, List<IndirectObject>> pair in items)
    	{
    		if (pair.Value.Count > 1)
    		{
    			duplicatesFound = true;
    			// shift field down to be a child of a new field node
    			int id = mDoc.AddObject("<< >>");
    			if (parentID > 0)
    			{
    				mDoc.SetInfo(parentID, "/Kids[]:Ref", id);
    				mDoc.SetInfo(id, "/Parent:Ref", parentID);
    			}
    			else
    			{
    				mDoc.SetInfo(acroFormID, "/Fields[]:Ref", id);
    			}
    			string[] dictEntries = new[] { "/FT", "/T", "/TU", "/Ff", "/V", "/DV" };
    			foreach (IndirectObject io in pair.Value)
    			{
    				foreach (string dictEntry in dictEntries)
    				{
    					string val = mDoc.GetInfo(io.ID, dictEntry);
    					if (!string.IsNullOrEmpty(val))
    					{
    						mDoc.SetInfo(id, dictEntry, val);
    						mDoc.SetInfo(io.ID, dictEntry + ":Del", "");
    					}
    				}
    				ArrayRemoveOneRefAtom(kids, io.ID);
    				mDoc.SetInfo(id, "/Kids[]:Ref", io.ID);
    				mDoc.SetInfo(io.ID, "/Parent:Ref", id);
    			}
    		}
    	}
    	if ((refreshForm) && (duplicatesFound))
    	{
    		mDoc.Form.Refresh();
    	}
    	return duplicatesFound;
    }
    
    private static bool ArrayRemoveOneRefAtom(ArrayAtom array, int id)
    {
    	if (array != null)
    	{
    		for (int i = 0; i < array.Count; i++)
    		{
    			RefAtom refAtom = array[i] as RefAtom;
    			if ((refAtom != null) && (refAtom.ID == id))
    			{
    				ArrayRemoveAt(array, i);
    				return true;
    			}
    		}
    	}
    	return false;
    }
    private static void ArrayRemoveAt(ArrayAtom array, int index)
    {
    	if (index == 0)
    	{ // Workaround for bug in some versions of ABCpdf
    		Atom[] copy = new Atom[array.Count];
    		array.CopyTo(copy, 0);
    		array.Clear();
    		for (int i = 1; i < copy.Length; i++)
    			array.Add(copy[i]);
    	}
    	else
    	{
    		array.RemoveAt(index);
    	}
    }
