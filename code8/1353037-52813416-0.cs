    // --- File MenuStep1.cs ---
    partial class Menu
    {
        // This array is populated with more and more items at every new steps
        readonly List<MenuItem> MenuItems = new List<MenuItem>();
        public void Show()
        {
            // Code to show menu here
        }
        // Suppose we have a Main here, but that's not necessary
        public static void Main()
        {
            new Menu().Show();   
        }
        // These are hooking methods to add menu items later
        partial void InitStep2();
        partial void InitStep3();
        partial void InitStep4();
        public Menu()
        {
            InitStep1();
            InitStep2();
            InitStep3();
            InitStep4();
        }
        
        void InitStep1()
        {
            // Code that adds menu items, but only for step 1
        }
    }
