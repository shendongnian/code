    public partial class Form1 : Form
    {
    OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=orcl;User ID=nareen1093;Password=nareen1093;Unicode=True");
    public Form1()
    {
        InitializeComponent();
        loadButton();
    }
    public void loadButton ()
    {
        con.Open();
        OleDbDataAdapter oda = new OleDbDataAdapter("select serial_number from fingerprint_device where serial_number like '%'", con);
        DataTable dt = new DataTable();
        oda.Fill(dt);
        comboBox1.DataSource = dt;
        comboBox1.DisplayMember = "serial_number";
        comboBox1.SelectedIndex = -1;
        con.Close();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Form2 form2 = new Form2();
        form2.ShowDialog();
        loadButton();
    }
    }
    public partial class Form2 : Form
    {
    OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=orcl;User ID=nareen1093;Password=nareen1093;Unicode=True");
    public Form2()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        con.Open();
        try
        {
            OleDbCommand cmd = new OleDbCommand("insert into fingerprint_device values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registration Success", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex + "", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            con.Close();
        }
    }
    }
