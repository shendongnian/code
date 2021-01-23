        public class MyCustomSelector : PXCustomSelectorAttribute
        {
	    	//Class used to display the data into the selector
            [Serializable]
            public class TableDummy : IBqlTable
            {
                #region Id
        
                [PXInt(IsKey = true)]
                [PXUIField(DisplayName = "Id")]
                public int? Id { get; set; }
        
                public class id : IBqlField { }
        
                #endregion
        
        
                #region Description
        
                [PXString(60, IsUnicode = true, InputMask = "")]
                [PXUIField(DisplayName = "Description", Visibility = PXUIVisibility.SelectorVisible)]
                public string Description { get; set; }
        
                public class description : IBqlField { }
        
                #endregion
            }
        
	    	//Selected table
            private Type _TableSelection;
            
	    	//Tables Ids. You can add as much field ID as you want
	    	private Type _TableFieldA;
            private Type _TableFieldB;
            private Type _TableFieldC;
	    	
	    	//Tables description fields
            private Type _TableAFieldDesc;
            private Type _TableBFieldDesc;
            private Type _TableCFieldDesc;
        
        
            public MyCustomSelector(Type tableSelection, Type tableFieldA, Type tableAFieldDesc, Type tableFieldB, Type tableBFieldDesc, Type tableFieldC, Type tableCFieldDesc) : base(typeof(TableDummy.id))
            {
                _TableSelection = tableSelection;
                _TableFieldA = tableFieldA;
                _TableFieldB = tableFieldB;
                _TableFieldC = tableFieldC;
                _TableAFieldDesc = tableAFieldDesc;
                _TableBFieldDesc = tableBFieldDesc;
                _TableCFieldDesc = tableCFieldDesc;
            }
        
	    	//Get the name of the selected table by using the privite field _TableSelection.
            private string GetSelection()
            {
                var cache = _Graph.Caches[_BqlTable];
                return cache.GetValue(cache.Current, _TableSelection.Name)?.ToString();
            }
        
	    	//Return a pompt instance based on the selected table in the dropdown.
            private PromptType GetSelectedTableField(string selectedTable)
            {
                switch (selectedTable)
                {
                    case "A":
                        return new PromptType() { Id = _TableFieldA, Description = _TableAFieldDesc };
                    case "B":
                        return new PromptType() { Id = _TableFieldB, Description = _TableBFieldDesc };
                    case "C":
                        return new PromptType() { Id = _TableFieldC, Description = _TableCFieldDesc };
                    default:
                        return new PromptType() { Id = _TableFieldA, Description = _TableAFieldDesc };
                }
            }
        
	    	//Return the records
            public IEnumerable GetRecords()
            {
                var selectedField = GetSelectedTableField(GetSelection());
                var selectedTable = BqlCommand.GetItemType(selectedField.Id);
                
                var select = BqlCommand.Compose(
                                typeof(Select<>),
                                    selectedTable
                                );
        
                var cmd = BqlCommand.CreateInstance(select);
                PXView view = new PXView(_Graph, true, cmd);
        
                foreach (var val in view.SelectMulti())
                {
                    var id = (int?)view.Cache.GetValue(val, selectedField.Id.Name);
                    var description = view.Cache.GetValue(val, selectedField.Description.Name)?.ToString();
                    yield return new TableDummy { Id = id, Description = description };
                }
            }
        }
