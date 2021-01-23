    var checklistbox = new List<string>
    {
         "asdf-432-qwer-vcxz",
         "rewq-123-qwer-vcxz",
         "rety-323-qw65-vcyt",
         "kjhf-232-ouyy-bjkl"
    };
    var onlineVaults = new List<string>
    {
         "rety-323-qw65-vcyt",
         "asdf-432-qwer-vcxz"
    };
    for (int i = 0; i < checklistbox.Items.Count; i++)
    {
        checklistbox.SetItemChecked(i, onlineVaults.Contains(checklistbox.Items[i]));            
    }
