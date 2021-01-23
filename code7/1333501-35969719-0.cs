    class ListBoxItem {
        public string DisplayName {get;set;}
        public string Identifier {get;set;}
    }
    ...
    ListBox.Items.Add(new ListBoxItem {
        DisplayName = "Book", Identifier = "m234"
    });
    ListBox.Items.Add(new ListBoxItem {
        DisplayName = "Clover", Identifier = "h67"
    });
    ListBox.Items.Add(new ListBoxItem {
        DisplayName = "Pencil", Identifier = "a12"
    });
    ListBox.Items.Add(new ListBoxItem {
        DisplayName = "Book", Identifier = "x67"
    });
    ListBox.DisplayMember = "DisplayName";
    ListBox.ValueMember = "Identifier";
