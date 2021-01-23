    var dispatcher = Application.Current.Dispatcher;
    //also could be a background worker
    Thread t1 = new Thread(() => 
                              {
                                   dispatcher .Invoke((Action)(() =>
                                   {
                                        login();    //or any action that update the view
                                   })); 
                                  //loginThread();
                              });
    t1.SetApartmentState(ApartmentState.STA);
    t1.Start();
    
