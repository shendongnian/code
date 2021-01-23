        public void AdjustColumns()
        {
            double availableSpace = this.ActualWidth;
            double starSpace = 0.0;
            double starFactor = 0.0;
            Dictionary<HTDataGridTemplateColumn, DataGridLengthAnimation> columnAnimations = new Dictionary<HTDataGridTemplateColumn, DataGridLengthAnimation>();
            Storyboard storyboard = new Storyboard();
            foreach (DataGridColumn column in this.Columns.AsParallel())
            {
                if (column.Visibility == Visibility.Visible && column.GetType() == typeof(HTDataGridTemplateColumn) && ((HTDataGridTemplateColumn)column).ResizeMode != HTDataGridTemplateColumn.ResizeModeOptions.None)
                {
                    DataGridLengthAnimation animation = new DataGridLengthAnimation
                    {
                        From = column.ActualWidth,
                        DataGridLengthUnitType = DataGridLengthUnitType.Pixel,
                        Duration = new Duration(TimeSpan.FromMilliseconds(250)),
                        FillBehavior = FillBehavior.Stop
                    };
                    column.Width = DataGridLength.Auto;
                    columnAnimations.Add((HTDataGridTemplateColumn)column, animation);
                    Storyboard.SetTarget(animation, column);
                    Storyboard.SetTargetProperty(animation, new PropertyPath(DataGridColumn.WidthProperty));
                    storyboard.Children.Add(animation);
                }
            }
            this.UpdateLayout();
            foreach (KeyValuePair<HTDataGridTemplateColumn, DataGridLengthAnimation> columnAnimation in columnAnimations)
            {
                if (columnAnimation.Key.ResizeMode == HTDataGridTemplateColumn.ResizeModeOptions.Fit)
                {
                    availableSpace -= columnAnimation.Key.Width.DesiredValue;
                    columnAnimation.Value.To = columnAnimation.Key.Width.DesiredValue;
                    columnAnimation.Value.Completed += (sender, args) =>
                    {
                        columnAnimation.Key.Width = new DataGridLength(columnAnimation.Key.Width.DesiredValue, DataGridLengthUnitType.Pixel);
                    };
                }
                else
                    starSpace += columnAnimation.Key.Width.DesiredValue;
            }
            if (starSpace > 0.0)
                starFactor = availableSpace/starSpace;
            foreach (KeyValuePair<HTDataGridTemplateColumn, DataGridLengthAnimation> columnAnimation in columnAnimations.Where(a => a.Key.ResizeMode == HTDataGridTemplateColumn.ResizeModeOptions.Stretch))
            {
                columnAnimation.Value.To = columnAnimation.Key.Width.DesiredValue * starFactor;
                columnAnimation.Value.Completed += (sender, args) =>
                {
                    columnAnimation.Key.Width = new DataGridLength(columnAnimation.Key.Width.DesiredValue * starFactor, DataGridLengthUnitType.Pixel);
                };
            }
            storyboard.Begin();
        }
    }
