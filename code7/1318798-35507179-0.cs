    public class UniLibDataGridView : DataGridView
    {
        public UniLibDataGridView()
        {
        }
        [Browsable(true)]
        [Description("Indicates has Counter Column.")]
        [Category("UniLib Tools")]
        [DisplayName("Has Counter Column")]
        [DefaultValue(false)]
        public bool HasCounterColumn
        {
            get { return Columns.Contains("Counter"); }
            set
            {
                if (value)
                    Columns.Add("Counter", "Counter");
                else if (Columns.Contains("Counter"))
                    Columns.Remove("Counter");
            }
        }
    }
