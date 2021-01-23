    async void button7_Click(object sender, EventArgs e)
    {
        var task = await Task.Run(() =>
        {
            Random rnd = new Random();
            var tbls = new List<Tbl>();
            for (int i = 0; i <= 1500; i++)
            {
                tbls.Add(new Tbl()
                {
                    Name = "User" + i + 1,
                    Num = rnd.Next(10, i + 10) / 10
                });
                progress.Report(i * 100 / 1500);
             }
            db.Tbls.AddRange(tbls);
            db.SaveChanges();
            return db.Tbls.Count();
        });
    }
