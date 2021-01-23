        for (int i = 0; i < ImportList.Count; i++)
        {
            // ...
            button.Text = ImportList[i].Scheme;
            button.Tag = i;
            button.Click += Button_Click;
        }
