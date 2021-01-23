            public IEnumerable<string> SelectableProperties { get; } = new List<string>()
            {
                nameof(M.Id),
                nameof(M.Number),
                nameof(M.Power),
            };
    
            // Selection in combobox 1 (not strictly necessary as it can be handled in view, but you may need to know what SelectedValue represents)
            private string _selectedValueMember = String.Empty;
            public string SelectedValueMember
            {
                get { return _selectedValueMember; }
                set { _selectedValueMember = value; }
            }
            // Selection in combobox 2 (object just in case there could be other values than int) 
            private object _selectedValue = null;
            public object SelectedValue
            {
                get { return _selectedValue; }
                set { _selectedValue = value; }
            }
    
            public ObservableCollection<M> FooBar{ get; set; }
