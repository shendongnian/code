    public void Getdataforoosh()
        {
            BindingSource b = new BindingSource();
            b.DataSource = (from m in _barforoosh.RadifsSendCenter
                            where m.Receive== false
                            select new
                            {
                                m.id_rec,m.Radifkolsal,m.Dates,m.DateErsal,m.TimeErsal,m.Karkhane,m.Namekala,m.Vazn,m.Bandal,m.Dobaskul,m.OldYear,
                                m.Sal,m.del,m.edit,m.Daryaft,m.Shobe,m.Greid,m.TedadBas,m.Rahgiry,m.Tozih,m.NoeShemsh,m.Metrazh,m.Keyfiat,m.Address,
                                m.City,m.Karbar,m.CodeKala,m.CodeGoruh,m.CodeKG,m.CodeGreid,m.Tel,m.ShenaseMeli,m.Sefaresh,m.Tolid,m.Shenase,
                            }).ToList();
            dataGridView1.DataSource = b;
    for (int i = 0; i < dataGridView1.RowCount; i++)
        {
            int c = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            var f = (from a in _barforoosh.RadifsSendCenter
                     where a.id_rec == c
                     select a).SingleOrDefault();
            f.Receive= true;
            
        }
    _barforoosh.SaveChanges();
            }
        }
