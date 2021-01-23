    private void button3_Click(object sender, EventArgs e)
    {
        ArrayList myarray2 = new ArrayList();
        addOnArray(myarray2, textBoxLectura1.Text);
        addOnArray(myarray2, textBoxLectura2.Text);
        addOnArray(myarray2, textBoxLectura3.Text);
       
        if (myarray2.Count > 0)
        {
            foreach (string values in myarray2)
            {
                Console.WriteLine(values );
            }
        }
        else
        {
            MessageBox.Show("no entrys");
        }
      }
