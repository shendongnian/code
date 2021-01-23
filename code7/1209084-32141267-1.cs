    public partial class Form2 : Form
    {
        public delegate void UpdateStatusHandler(string status);
        public event UpdateStatusHandler OnStatusUpdated;
        public Form2()
        {
            //Start thread here
            if (OnStatusUpdated != null)
            {
                OnStatusUpdated("I am going to start work");
            }
            //Doing a lot of work here
            if (OnStatusUpdated != null)
            {
                OnStatusUpdated("Some of work has been done");
            }
            //Do other
            if (OnStatusUpdated != null)
            {
                OnStatusUpdated("Now I am ready to load the form");
            }
        }
    }
