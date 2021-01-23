    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (string file in Directory.GetFiles("\\\\Mypcname-PC\\vxheaven\\malware"))
            {
                count++;
                label1.Text = Convert.ToString(count);
                Application.DoEvents();
                if (file.Contains(textBox1.Text))
                {
                    label1.Text = Convert.ToString(count) + " reached the file";
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
