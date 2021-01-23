     void f_ValueChanged(object sender, EventArgs e)
      {
        Boolean isThisProgrammatic = isProgrammaticEvent;
        isProgrammaticEvent = false;
        if(isThisProgrammatic)
            return;
      }
