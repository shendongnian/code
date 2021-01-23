	foreach (var key in global.Keys)
	{
		if(IsTable(global.Get(key.String)))
		{
			Console.WriteLine("-------" + key.ToPrintString() + "-------");
			Table characterData = global.Get(key.String).ToObject<Table>();
			foreach (var characterDataField in characterData.Keys)
			{
				if( !IsTable(characterData.Get(characterDataField.String)))
				{
					Console.WriteLine(string.Format("{0} = {1}", characterDataField.ToPrintString(), characterData.Get(characterDataField.String).ToPrintString()));
				}
				else
				{
					Console.WriteLine(string.Format("{0} = {1}", characterDataField.ToPrintString(), "Table[]"));
				}
			}
			Console.WriteLine("");
		}
	}
