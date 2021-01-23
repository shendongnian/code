    string boy = boyBox.Text;
    using (StreamReader sr = new StreamReader("D:\\BoyNames.txt"))
    {
          string boyinputFile = sr.ReadToEnd();
          if (boyinputFil.Contains(boy))
          {
               MessageBox.Show("Yes, your name is popular!");
          }
          else
          {
               MessageBox.Show("Sorry, couldn't find your name.");
          }
    }
