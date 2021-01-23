    DataView _view = GettingDataFromFunctionCall();
    List<string> _list = new List<string>();
    // Populated from factory.
    _list = _view.ToTable()
                 .AsEnumerable()
                 .Select(row => row[1].ToString())
                 .ToList<string>();
    // Construct list of word from textbox.
    List<string> words = txtName.Text.ToLower().Split(' ').ToList();
    
    // Update ListView
    ListView.ListViewItemCollection lvic = new ListView.ListViewItemCollection(lvName);
    lvName.BeginUpdate();
    lvName.Items.Clear();
    lvic.AddRange(_list .AsParallel()
                    .Where(x => words.All(word => x.ToLower().Contains(word)))
                        .AsParallel()
                        .Select(t => new ListViewItem(t))
                        .ToList()
                        .ToArray());
    lvName.EndUpdate();
