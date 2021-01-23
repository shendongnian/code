    partial void copy1_Execute()
        {
            // Write your code here.
            string Copylink1, dLink1;
            Downloadable copydl = this.Downloadables.SelectedItem;
            dLink1 = Convert.ToString(copydl.Link1);
            Copylink1 = dLink1;
            Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke(() =>
                {
                Clipboard.SetText(Copylink1);
                });
            this.ShowMessageBox("Link copied to clipboard. Ctrl + V to paste", "Downloadable", MessageBoxOption.Ok);
        }
