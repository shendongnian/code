     static void Main(string[] args)
            {
                string str = "0,A 1,B 2,C 3,D 4,E";
                var values = str.Where(c => char.IsDigit(c)).ToArray();
                var quads = str.Split(' ').Select(st=>st.Split(',')[1]).ToArray();  
    
            }
