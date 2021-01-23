    private void button_Click(object sender, RoutedEventArgs e)
        {
            show.Text = inputText.Text;
            //Debug.WriteLine(check1_cont.ToString());
            //Debug.WriteLine(check2_cont.ToString());
            if (check1_cont && check2_cont == true )
            {
                show2.Text = inputText.Text;
                // Copy the text to output
                string outputToWrite = inputText.Text;
                // use the copied text
                Task.Run(() => File.WriteAllText(@"A:\temp\name.txt", outputToWrite));
            }
        }
