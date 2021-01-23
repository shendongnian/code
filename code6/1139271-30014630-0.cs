    Holder m_Holder = new Holder();
    MedApp m_MedApp = new MedApp(m_Holder);
...
    class MedApp
    {
      Holder m_Holder;
      public MedApp(Holder holder) {
          m_Holder = holder;
      }
      public void pShowValue()
      {
          MessageBox.Show("!!! This should show value 1, but shows :  " +    m_Holder.LoggedIn.ToString());
      }      
    }
