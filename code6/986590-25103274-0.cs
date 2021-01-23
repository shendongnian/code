        while (true) {
            try {
                BeginAccept(baseListernerNewVer);
                break;
            }
            catch(Exception e) {
                System.Threading.Thread.Sleep(100);
            }
        }
