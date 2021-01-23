    for (int i = 0; i < tabControl1.TabCount; i++)
    {
         foreach (TextBox textBox in tabControl1.TabPages[i].Controls.OfType<TextBox>().Cast<TextBox>())
         {
              textBox.Text = "";//or something else
         }
    }
