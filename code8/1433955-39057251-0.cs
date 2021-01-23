        private int taskId = 0;
        private async void ExecAutoComplete()
        {
            var client_list = App.ClientManager.GetTasksAsync(txtClientFilter.Text);
            var template = new DataTemplate(typeof(TextCell));
            template.SetBinding(TextCell.DetailProperty, "nom_ct");
            template.SetBinding(TextCell.TextProperty, "cod_ct");
            listview.ItemTemplate = template;
            listview.ItemsSource = await client_list;
        }
        private void TryExecute(int taskId)
        {
            if (this.taskId == taskId)
                ExecAutoComplete();
        }
        private async void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ++taskId;
            Task.Delay(1000).ContinueWith(t =>  TryExecute(taskId));
        }
