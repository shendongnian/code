    public class DataGridViewFocused : DataGridView
    {
        public bool ShowFocus { get; set; }
        protected override bool ShowFocusCues
        {
            get
            {
                return this.ShowFocus;
            }
        }
    }
    DataGridViewFocused dataGridView1 = new DataGridViewFocused();
    dataGridView1.ShowFocus = true;
