      // Smells: 
      // 1. Ugly arguments: 
      //   sender (what is it? Can I ,say, pass 123 as a sender)
      //   e (why on Earth should I generate event args when all I want is to append a file?!)
      // 2. Wrong name: Form2_KeyUp (very bad name to writing file routine)
      public void Form2_KeyUp(object sender, KeyEventArgs e) {
        listBox1.Items.Add(e.KeyCode);
        // wrap IDisposable into using
        StreamWriter sw = new StreamWriter(@"d:\Prova.txt", true);
        sw.Write(e.KeyCode);
        sw.Close();
      }
