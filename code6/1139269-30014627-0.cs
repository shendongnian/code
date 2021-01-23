    class MedApp
    {
        public Holder m_Holder = new Holder();
        public void IncrementHolder()
        {
           ++m_Holder.LoggedIn;
        }
        public void pShowValue()
        {
           MessageBox.Show("!!! This should show value 1, but shows :  " + 
                           m_Holder.LoggedIn.ToString());
        }      
    } 
