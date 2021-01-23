      static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.D1:
                    
                    var thread1 = new Thread(new ParameterizedThreadStart(param => { CaptureAreaOfScreenForm caos2 = new CaptureAreaOfScreenForm();caos2.Show(); }));
                    thread1.SetApartmentState(ApartmentState.STA);
                    thread1.Start();
                    break;
                case Keys.D2:
                    CaptureWorkingArea cwa2 = new CaptureWorkingArea();
                    var thread2 = new Thread(new ParameterizedThreadStart(param => { cwa2.CaptureTheWorkingArea(); }));
                    thread2.SetApartmentState(ApartmentState.STA);
                    thread2.Start();
                    break;
                case Keys.D3:
                    CaptureFullScreen cfs2 = new CaptureFullScreen();
                    var thread3 = new Thread(new ParameterizedThreadStart(param => { cfs2.CaptureDesktop(); }));
                    thread3.SetApartmentState(ApartmentState.STA);
                    thread3.Start();
                    break;
                case Keys.D4:
                    CaptureAllScreens cas2 = new CaptureAllScreens();
                    var thread4 = new Thread(new ParameterizedThreadStart(param => { cas2.CaptureScreens(); }));
                    thread4.SetApartmentState(ApartmentState.STA);
                    thread4.Start();
                    break;
                case Keys.D5:
                    UploadFromFile uff2 = new UploadFromFile();
                    var thread5 = new Thread(new ParameterizedThreadStart(param => { uff2.UploadFile(); }));
                    thread5.SetApartmentState(ApartmentState.STA);
                    thread5.Start();
                    break;
            }
            //collect the garbage
            GC.Collect();
        }
