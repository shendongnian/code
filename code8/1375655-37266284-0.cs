     BaskoolEntities be = new BaskoolEntities();
     BarForooEntities1 bfe = new BarForooEntities1();
     var q = (from d in bfe.RadifsSendCenter
         where d.id_rec > last
         orderby d.id_rec
         select new
                   {d.id_rec,d.Radifkolsal,d.Namekala,d.Vazn,d.Bandal,d.Greid,d.TedadBas,d.Tozih,d.NoeShemsh,d.Metrazh,d.Keyfiat,d.Address,d.City,d.Tel,d.ShenaseMeli,d.Sefaresh,d.Tolid,d.Shenase
                         }).ToList();
            {
     foreach (var v in q)
                {
                    RadifsSendCenter s = new RadifsSendCenter();
                    SaleHistory sh = new SaleHistory();
                    sh.id_rec = v.id_rec;
                    sh.Radifkolsal = v.Radifkolsal;
                    sh.Namekala = v.Namekala;
                    sh.Vazn = v.Vazn;
                    sh.Bandal = v.Bandal;
                    sh.Greid = v.Greid;
                    sh.TedadBas = v.TedadBas;
                    sh.Tozih = v.Tozih;
                    sh.NoeShemsh = v.NoeShemsh;
                    sh.Metrazh = v.Metrazh;
                    sh.Keyfiat = v.Keyfiat;
                    sh.Address = v.Address;
                    sh.City = v.City;
                    sh.Tel = v.Tel;
                    sh.ShenaseMeli = v.ShenaseMeli;
                    sh.Sefaresh = v.Sefaresh;
                    sh.Tolid = v.Tolid;
                    sh.Shenase = v.Shenase;
                    var u = (from bu in be.BarbariUsers
                        where bu.UserName == Login.username
                        select bu).FirstOrDefault();
                    sh.UserID = u.UserID;
                    sh.ReceiveUser = Login.username;
                    sh.ReceiveDateTime = DateTime.Now;
                    var b= (from h in bfe.RadifsSendCenter
                        where h.id_rec == q.id_rec
                        select h).FirstOrDefault();
                    b.Daryaft = false;
                    be.SaleHistory.Add(sh);
                }
        be.SaveChanges();
        bfe.SaveChanges();
        }
        MessageBox.Show("Done!");
        }
