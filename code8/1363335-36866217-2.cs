    public class Model
    {
        public int Val1{get;set;}
        public string Val2{get;set;}
        public void Save()
        {
            SelectedCategory sc = new SelectedCategory();
            using(SQLiteConnection con = new SQLiteConnection("  Data Source=database.sqlite; Version=3; Compress=True; "))
            {
                con.Open();
                string query = " INSERT INTO income_details (name, amount)  VALUES (@1, @2) ";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.Add(new SQLiteParameter("@1", Val1);
                cmd.Parameters.Add(new SQLiteParameter("@2", Val2);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
            }
        }
    )
