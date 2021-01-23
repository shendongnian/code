        private string studentName;
        public string StudentName
        {
            get { return this.studentName; }
            set { this.Set(() => this.StudentName, ref this.studentName, value); }
        }
        private void Set(Func<string> func, ref string s, string value)
        {           
        }
