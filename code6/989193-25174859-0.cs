    class X // A, B, C are key in the database table
    { 
        string A { get; set; } 
        string B { get; set; } 
        string C { get; set; }
        .... 
    
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", A, B, C);
        }
    }
    var l = GetListOfX();
    ComboBox1.DataSource = l; // that's all, you don't need to set value member or display member
