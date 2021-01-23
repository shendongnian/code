    public class MyForm
    {
 
    // To store your currently loaded values
    private List<String[]> values;
    // Load button
    ...
        using (StreamReader master = File.OpenText(@"C:\Master.txt")) //txt to table
        {
            this.values = new List<String[]>();
            int row = 0;
            string s = String.Empty;
            while ((s = master.ReadLine()) != null)
            {
                string[] columns = s.Split(',');
                // Save the line
                values.Add(columns);
                dataGridView1.Rows.Add();
                for (int i = 0; i < columns.Length; i++)
                {
                    dataGridView1[i, row].Value = columns[i];
                }
                row++;
            }
        }
