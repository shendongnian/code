    lock (SyncItems)
    {
        // Hacky way to do an Invoke
        Application.OpenForms[0].Invoke((Action)(() =>
        {
            Items[Items.IndexOf(item)].Url += " "; // Force listbox to call DrawItem by changing the DisplayMember
            Items[Items.IndexOf(item)].Content = content;
        }));
    }
