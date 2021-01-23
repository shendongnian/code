    public partial class PPAP_Edit : Form 
    {
        // set this from constructor
        public string MainDir { get; set; }
        // can't set this in constructor as it requires access to form controls, but can just use the getter
        public string SubDir
        { 
            get 
            { 
                return text_PSW_ID.Text + "_" + text_Partnumber.Text + "_" + text_Partrev.Text + @"\"; 
            } 
        }
        // again just use the getter
        public string TargetPath 
        {
            get 
            {
                return Path.Combine(MainDir, SubDir);
            }
        }
        // set defaults in constructor 
        public PPAP_Edit()
        {
            MainDir = @"C:\Users\h109536\Documents\PPAP\";
        }
    }
