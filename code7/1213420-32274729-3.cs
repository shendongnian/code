    string text = "";
    using (StreamReader sr = new StreamReader("C:\\Users\\Donavon\\Desktop\\old.sql"))
    {
        int i = 0;
        do
        {
            i++;
            string line = sr.ReadLine();
            if (line != "")
            {
                line = line.Replace("('',", "('" + i + "',");
                text = text + line + Environment.NewLine;
            }
        } while (sr.EndOfStream == false);
    }
    File.WriteAllText("C:\\Users\\Donavon\\Desktop\\new.sql", text);
