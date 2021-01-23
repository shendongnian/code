    using System.Reflection;
    
    private void LoadNewForm(string formName)
    {
        try
        {
            Assembly assembly = Assembly.LoadFile("c:\\ClassLibrary1.dll");
            Type type = assembly.GetType(formName);
            Form frm = (Form) Activator.CreateInstance(type);
    
            frm.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        LoadNewForm("ClassLibrary1.Form1");
    }
