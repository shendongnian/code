        using (StreamReader rdr = new StreamReader(file))
        {
            string line;// for Name
            string line2;//for Age
            while ((line = rdr.ReadLine()) != null)
            {
                line2= rdr.ReadLine();
                info1.Add(new Info(line,line2));                  
            }
        }
        return info1;
    }
