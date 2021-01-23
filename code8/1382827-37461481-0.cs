    DBconnect connectDB = new DBconnect();
        List<string>[] persGegevens = connectDB.persoonlijkeGegevens(userId);
        for (int i = 0; i <= persGegevens.Count(); i++)
        {
            switch (i)
            {
                case 0:
                    break;
                case 1:
                    lblVoornaamVrbl.Text = persGegevens[i][0].ToString();
                    break;
                case 2:
                    lblAchternaamVrbl.Text = persGegevens[i][1].ToString();
                    break;
                case 3:
                    lblGbrtedatumVrbl.Text = persGegevens[i][2].ToString();
                    break;
                case 4:
                    lblFuntieVrbl.Text = persGegevens[i][3].ToString();
                    break;
                default:
                    break;
            }
        }
