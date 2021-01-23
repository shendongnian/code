    private void btn_Test_Click(object sender, EventArgs e)
    {
        using(ServiceReference1.EngineClient eng = new EngineClient())
        {
            textBox1.Text = eng.Test();
        }
    }
