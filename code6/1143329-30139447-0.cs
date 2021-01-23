        void OnLayoutUpdated(object sender, EventArgs e)
        {
            double countersMinWidth = CountersList.Columns[0].ActualWidth + CountersList.Columns[1].ActualWidth + CountersList.Columns[2].ActualWidth + CountersList.Margin.Left + CountersList.Margin.Right;
            double soundsMinWidth = SoundsList.Columns[0].ActualWidth + SoundsList.Columns[1].ActualWidth + SoundsList.Columns[2].ActualWidth + SoundsList.Margin.Left + SoundsList.Margin.Right;
            if (countersMinWidth < 205) countersMinWidth = 205;
            if (soundsMinWidth < 205) soundsMinWidth = 205;
            Grid.ColumnDefinitions[0].MinWidth = countersMinWidth;
            Grid.ColumnDefinitions[2].MinWidth = soundsMinWidth;
            this.MinWidth = countersMinWidth + soundsMinWidth + Splitter.ActualWidth + 18;
        }
