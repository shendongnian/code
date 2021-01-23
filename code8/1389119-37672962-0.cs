     protected void MyCheckBox_CheckedChanged(object sender, EventArgs e)
            {
                if (MyCheckBox.Checked)
                {
                    Response.Write("CheckeD");
                }
                else
                {
                    Response.Write("Un CheckeD");
                }
            }
