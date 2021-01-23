    class Summary
    {
        public Summary(int emp_num, DataRow rowOff, DataRow rowOn)
        {
            this.emp_num = emp_num;
            
            if (rowOff != null)
            {
                salary_off = (int)rowOff["salary"];
                ov_off = (double)rowOff["ov"];
            }
            
            if (rowOn != null)
            {
                salary_on = (int)rowOn["salary"];
                ov_on = (double)rowOn["ov"];
            }
        }
        public int emp_num;
    
        public int salary_off ;
        public int salary_on;
        public bool salarySame { get { return salary_off == salary_on; }  }
    
        public double ov_off ;
        public double ov_on;
        public bool ovSame { get { return ov_off == ov_on; } }
        
    }
