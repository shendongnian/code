            ArrayList myarray2 = new ArrayList();
            int index = !string.IsNullOrWhiteSpace(textBoxLectura1.Text) ? myarray2.Add(textBoxLectura1.Text) : -1;
            index = !string.IsNullOrWhiteSpace(textBoxLectura2.Text) ? myarray2.Add(textBoxLectura2.Text) : -1;
            index = !string.IsNullOrWhiteSpace(textBoxLectura3.Text) ? myarray2.Add(textBoxLectura3.Text) : -1;
            if (myarray2.Count > 0)
            {
                foreach (string values in myarray2)
                {
                    Console.WriteLine(values);
                }
            }
            else
            {
                MessageBox.Show("no entrys");
            }
