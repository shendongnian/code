    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            DataTable dt; // values here
            MyComboBox cb = new MyComboBox();
            cb.InitItems(dt);
            MyDataGridViewComboBoxColumn gvcb = new MyDataGridViewComboBoxColumn();
            cb.InitItems(dt);
        }
    }
    public class MyComboBox : ComboBox, Itest
    {
        // apply Sir Rufo answer here
        public void InitItems(DataTable table)
        {
            Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                Items.Add(row);
            }
        }
    }
    public class MyDataGridViewComboBoxColumn: DataGridViewComboBoxColumn, Itest
    {
        // apply Sir Rufo answer here
        public void InitItems(DataTable table)
        {
            Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                Items.Add(row);
            }
        }
    }
    public interface Itest
    {
        void InitItems(DataTable table);
    }
