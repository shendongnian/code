      private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var WriteToFile = new System.IO.StreamWriter("student.txt"); //create textfile in default directory
                WriteToFile.Write(txtStudNum.Text + ", " + txtStudName.Text + ", " + txtModCode.Text + ", " + txtModMark.Text);
                WriteToFile.Close();
               marks.Add(Convert.ToInt32(txtModMark.Text)); //add to list
            }
    
            catch (System.IO.DirectoryNotFoundException ex)
            {
                //add error message
            }
        }
