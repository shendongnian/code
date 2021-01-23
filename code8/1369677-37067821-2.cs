       private int m_ID;
       public int ID {
         get {
           return m_ID;
         }
         set {
           m_ID = value;
           txtinvoiceno.Text = m_ID.ToString("00000"); 
         }
       }      
       ...
       protected void Page_Load(object sender, EventArgs e) {
         // Just assign
         ID = 0;
         ... 
       }
       protected void btnsavef1_Click(object sender, EventArgs e) {
         // Just increment 
         ID += 1;
       } 
