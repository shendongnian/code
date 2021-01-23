    while ((line=sr.ReadLine())!=null)
    {
        User user = new User();
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 1:
                    user.ID = line;
                    break;
                case 2:
                    user.Name=sr.ReadLine();
                    break;
                ....
            }
        }
    }
     
