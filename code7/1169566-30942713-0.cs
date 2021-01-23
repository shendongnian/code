    public  List <Linkses> Gettha()
            {
                List<Linkses> lin = new List<Linkses>();
                using (var statement = con.Prepare("SELECT _id, link FROM links"))
                {
                     while (statement.Step() == SQLiteResult.ROW)
                     {
                         Linkses link = new Linkses();
                         link.Id = (long)statement[0];
                         link.Linochka = (string)statement[1];
                         lin.Add(link);
                        }
                }
                return lin;
            }
