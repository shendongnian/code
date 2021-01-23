    public class DropDownDayPicker : Control
    {
        private List<CheckBox> checkboxes = new List<CheckBox>();
        static DropDownDayPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownDayPicker), new FrameworkPropertyMetadata(typeof(DropDownDayPicker)));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            StackPanel weekdayBoxes = this.GetTemplateChild("PART_weekdayHost") as StackPanel;
            foreach(CheckBox box in weekdayBoxes.Children)
            {
                box.Checked += Box_CheckedChanged;
                box.Unchecked += Box_CheckedChanged;
                this.checkboxes.Add(box);
            }
            Button openPopup = this.GetTemplateChild("PART_openPopupButton") as Button;
            openPopup.Click += OpenPopup_Click;
            this.UpdateCheckboxes();
        }
        private void OpenPopup_Click(object sender, RoutedEventArgs e)
        {
            Popup popup = this.GetTemplateChild("PART_popup") as Popup;
            popup.IsOpen = !popup.IsOpen;
            
        }
        private void Box_CheckedChanged(object sender, RoutedEventArgs e)
        {
            this.UpdateSelectedWeekdays();
        }
        public ObservableCollection<Weekday> SelectedWeekdays
        {
            get { return (ObservableCollection<Weekday>)GetValue(SelectedWeekdaysProperty); }
            set { SetValue(SelectedWeekdaysProperty, value); }
        }
        
        public static readonly DependencyProperty SelectedWeekdaysProperty =
            DependencyProperty.Register("SelectedWeekdays", typeof(ObservableCollection<Weekday>), typeof(DropDownDayPicker), new PropertyMetadata(new ObservableCollection<Weekday>(), SelectedWeekdaysPropertyChanged));
        private static void SelectedWeekdaysPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            DropDownDayPicker picker = sender as DropDownDayPicker;
            ObservableCollection<Weekday> oldValue = args.OldValue as ObservableCollection<Weekday>;
            ObservableCollection<Weekday> newValue = args.NewValue as ObservableCollection<Weekday>;
            if (picker != null)
            {
                if (oldValue != null)
                {
                    oldValue.CollectionChanged -= picker.SelectedWeekdaysChanged;
                }
                if (newValue != null)
                {
                    newValue.CollectionChanged += picker.SelectedWeekdaysChanged;
                }
                picker.UpdateCheckboxes();
            }
        }
        private void SelectedWeekdaysChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.UpdateCheckboxes();
        }
        private bool updating = false;
        private void UpdateCheckboxes()
        {
            if (!this.updating)
            {
                this.updating = true;
                if (this.SelectedWeekdays != null)
                {
                    foreach (CheckBox box in this.checkboxes)
                    {
                        box.IsChecked = this.SelectedWeekdays.Contains((Weekday)box.Tag);
                    }
                }
                this.UpdateSummary();
                this.updating = false;
            }
        }
        private void UpdateSelectedWeekdays()
        {
            if (!this.updating)
            {
                this.updating = true;
                var selectedWeekdays = this.checkboxes.Where(x => x.IsChecked.HasValue && x.IsChecked.Value).Select(x => x.Tag).Cast<Weekday>();
                this.SelectedWeekdays = new ObservableCollection<Weekday>(selectedWeekdays);
                this.UpdateSummary();
                this.updating = false;
            }
        }
        private void UpdateSummary()
        {
            TextBlock summary = this.GetTemplateChild("PART_summary") as TextBlock;
            if (this.SelectedWeekdays != null)
            {                
                if (this.SelectedWeekdays.Count == 0)
                {
                    summary.Text = "none";
                }
                else if (this.SelectedWeekdays.Count == 1)
                {
                    summary.Text = this.SelectedWeekdays[0].ToString();
                }
                else if (this.SelectedWeekdays.Count > 1)
                {
                    summary.Text = string.Format("{0} days",this.SelectedWeekdays.Count);
                }
            }
            else
            {
                summary.Text = "none";
            }
        }
    }
