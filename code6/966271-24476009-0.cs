    public class myCombo : ComboBox
    {
        public myCombo()
        {
            DrawItem += new DrawItemEventHandler(DrawCustomMenuItem);
        }
        protected  void DrawCustomMenuItem(object sender, DrawItemEventArgs e)
        {
            // do your drawstuff
        }
       
    }
