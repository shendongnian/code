    progressControl.Visibility = Visibility.Visible;
    try {
       if (query.Count() == 1) {
           System.Threading.Thread.Sleep(3000);
           frm_main mainFrm = new frm_main();
           mainFrm.Show();
           this.Hide();
       }
    } 
    finally {
       progressControl.Visibility = Visibility.Collapsed;
    }
