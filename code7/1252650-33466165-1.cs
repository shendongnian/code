    using (StreamWriter txt = new StreamWriter("D:\\Register.txt"))
    {
        txt.WriteLine(string.Format("{0}: {1}", Namelabel.Text, NametextBox.Text));
        txt.WriteLine(string.Format("{0}: {1}", passlabel.PasstextBox, NametextBox.Text));
    }
