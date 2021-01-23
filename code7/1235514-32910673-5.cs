    for(int i = 0; i < numberOfFields; i++)
    {
         TextBox generatedField = new TextBox();
         generatedField.Name = "someName_" + i.ToString();
         generatedField.Text = "Please enter Field Report ID Here";
         generatedField.Width = 176;
         generatedField.Location = new Point(pointX, pointY);
         panel1.Controls.Add(generatedField);
         panel1.Show();
         pointY += 25;
    }
