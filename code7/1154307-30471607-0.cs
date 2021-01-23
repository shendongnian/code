        public Class1()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new Label();
            this.time = new Label();
            this.time_in_hour = new Label();
            this.time_in_minutes = new Label();
            this.time_in_seconds = new Label();
            this.colon1 = new Label();
            this.colon2 = new Label();
            this.start = new Button();
            this.totalSeconds = new TextBox();
            this.pause = new Button();
            this.delete = new Button();
            this.countTimers = new Label();
        }
        public Label countTimers { get; set; }
        public System.Windows.Forms.Panel panel { get; set; }
        public Label label1 { get; set; }
        public Label time { get; set; }
        public Label time_in_hour { get; set; }
        public Label time_in_minutes { get; set; }
        public Label time_in_seconds { get; set; }
        
        public Label colon1 { get; set; }
        public Label colon2 { get; set; }
        public TextBox totalSeconds { get; set; }
        public Button start { get; set; }
        public Button pause { get; set; }
        public Button delete { get; set; }
    }
}
