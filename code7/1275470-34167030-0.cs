     try
        {
            string name = nameTextBox.Text;
            string number = numberTextBox.Text;
            using (TextWriter tsw = new StreamWriter("PhoneList.txt", true))
			{
				tsw.WriteLine(name + ", " + number);
			}
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
