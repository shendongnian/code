    output progressWindow = null;
    private void button1_Click(object sender, EventArgs e)
    {            
            if(progressWindow == null)
                progressWindow = new output();
            if (visible == false)
            {
                progressWindow.Show();
                button1.Text = "Hide Progress";
                visible = true;
            }
            else
            {
                progressWindow.Hide();
                button1.Text = "Show Progress";
                visible = false;
            }
        }
    }
