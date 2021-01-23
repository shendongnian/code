    class DataTableTools
    {
        public LineType LineType { get; set; }
        public LineData LineData { get; set; }
    
        public bool InsertData(LineData lineData)
        {
            this.LineData.angle = lineData.angle
    		...
            return true;
        }
    }
