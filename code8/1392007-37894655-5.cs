    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            string pathfile = @"C:\Users\Raman\Desktop\Real Data\";
            string filename = "Data.csv";
            using(FileStream fs = new FileStream(
                Path.Combine(pathfile, filename), 
                FileMode.Append, 
                FileAccess.Write))
            {
                using(StreamWriter s = new StreamWriter(fs))
                {
                  foreach(var reading in readings)
                  {
                     // format the output
                     s.WriteLine(
                       "{0:yyyy-MM-dd hh:mm:ss},{1},{2}",
                       reading.CreationDate,
                       reading.A,
                       reading.B
                     );
                  }
                }
               MessageBox.Show("Data has been saved to" + pathfile,"Save File");
            }
        }
        catch(Exception exp) 
        {
             MessageBox.Show(exp.Message,"Error");
        }
    }
