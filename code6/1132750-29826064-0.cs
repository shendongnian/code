    private void button3_Click(object sender, EventArgs e)
            {
    
                ArrayList myarray2 = new ArrayList();
    
                ChecknAdd(textBoxLectura1, myarray2);
                ChecknAdd(textBoxLectura2, myarray2);
                ChecknAdd(textBoxLectura3, myarray2);
    
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
    
            }
    
            void ChecknAdd(TextBox txt, System.Collections.ArrayList Ary)
            {
                if (string.IsNullOrWhiteSpace(txt.Text) == false)
                {
                    Ary.Add(txt.Text);
                }
            }
