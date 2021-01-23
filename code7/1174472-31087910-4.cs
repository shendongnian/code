    output progressWindow = null;
    private void button1_Click(object sender, EventArgs e)
    {            
            if(progressWindow == null)
                progressWindow = new output();
            if (button1.Text == "Show Progress";)
            {
                progressWindow.Show();
                button1.Text = "Hide Progress";
            }
            else
            {
                progressWindow.Hide();
                button1.Text = "Show Progress";
            }
        }
    }
