    public class Departmentinfo
    {
        public string departmentname;
        
        private void Departmentinfo(string s)
        {
            this.departmentname = s;
        }
    }
    List<Departmentinfo> DepInfo = new List<Departmentinfo>();
    private void getdepartments()
    {
        for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DepInfo.Add(new Departmentinfo(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value)));
            }
    }
    private void putdepartments()
    {
        foreach (Departmentinfo dep in DepInfo)
        {
            comboBox4.Items.Add(dep.departmentname);
        }
    }
