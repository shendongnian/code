      string idYouSearched = "2";
      var encoding = Encoding.GetEncoding("iso-8859-1");
      var csvLines = File.ReadAllLines(fileName,encoding);
   
      foreach (var line in csvLines )
         {
            var values = line.Split(',');
            if(values[0].Contains(idYouSearched))
               {
                  richTextBox1.Text += "Name: " + values[1] + 
                                  "\nSurname: " + values[2] + 
                                 "\nJob Role: " + values[3] + 
                                  "\nSalary: £" + values[4];
               }
          }
   
      It`s much simpler and you not holding open stream when working with the UI.
