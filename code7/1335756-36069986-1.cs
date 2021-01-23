    public class ProjectTwoClass
    {
        public ProjectOneClass pOne;
    
        // other stuff
    
        public ProjectTwoClass()
        {
            pOne = new ProjectOneClass();
            pOne.UpdateUIEvent += POneOnUpdateUIEvent;
        }
    
        public void POneOnUpdateUIEvent(object sender, EventArgs eventArgs)
        {
            ClearAll();
        }
    
        private void ClearAll()
        {
            tbFile.Text = string.Empty; // could probably just call tbFile.Clear();
        }
    }
