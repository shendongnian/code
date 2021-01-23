      ArrayList arraylist2 = new ArrayList();
        ArrayList arraylist4 = new ArrayList();
        private void button1_Click(object sender, EventArgs e)
        {
            arraylist2.Add("SomeVal");
            arraylist4.Add("SomeVal");
            if (arraylist2.Count > 0 && arraylist4.Count > 0)
            {
                MessageBox.Show(arraylist2.ToString() + "<br />" + arraylist4.ToString() + "<br />");
            }
            else
            {
                MessageBox.Show("not array values");
            }   
        }
