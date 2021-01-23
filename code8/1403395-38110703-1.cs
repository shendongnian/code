    private async void List2_Dropped(object sender, DragEventArgs e)
    {
        if (e.DataView.Contains(StandardDataFormats.Text))
        {
            var def = e.GetDeferral();
            var s = await e.DataView.GetTextAsync();
            var ids = s.Split('\n');
            if (ids.Length > 0)
            {
                foreach (string id in ids)
                {
                    // get the object for the ID here
                }
            }
            e.AcceptedOperation = DataPackageOperation.Copy;
            def.Complete();
        }
    }
