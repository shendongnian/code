    string line = "";
    int index = 0;
    using (StreamReader sr = File.OpenText("PathToFile"))
    {
        while ((line = sr.ReadLine()) != null)
        {
            index++;
            if(index == 1)
                Textbox1.Text = line;
            else if(index == 2)
                Textbox2.Text = line;
            else if(index == 3)
                Listbox1.Items.Add(line);
            else
                break;
        }
    }
