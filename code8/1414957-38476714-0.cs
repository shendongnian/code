            TabControl zakladki = (TabControl)Controls.Find("zakl", false).FirstOrDefault();
            Control kt = Controls["nowy"];
            kt.Location = new Point(10, 10);
            zakladki.TabPages[0].Controls.Add(kt);
        }
