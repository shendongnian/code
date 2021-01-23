    class MedApp
      {
          // Remove this
          //public Holder m_Holder = new Holder();
    
          public void pShowValue(Holder mHolder) /* Add parameter here */
          {
              MessageBox.Show("!!! This should show value 1, but shows :  " + mHolder.LoggedIn.ToString());
          }      
      }
