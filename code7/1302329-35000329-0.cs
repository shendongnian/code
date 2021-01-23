       List<Players> player = new List<Players>();
            using (var contxt = new lotteryEntities1())
            {
                var AllPlayer = contxt.GetAllPlayars();
                foreach(var pp in AllPlayer)
                {
                    player.Add(new Players() { PalyerName = pp.Player_name, PlayerPhone = pp.Player_Phone,Pics=pp.Photo});
                }
                DTGridEmp.ItemsSource = player;
                //  DTGridEmp.ItemsSource = items;
            }
