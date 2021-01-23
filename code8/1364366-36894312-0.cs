      public **static** string getUSERID  
      {
         get
          {
            return userID;
          }
       }
       private void Form2_Load(object sender, EventArgs e)
       {
            UserID = Form1.getUSERID(); // If the property has static it's possible to write like this.
       }
     
       (or)
      
      public string getUSERID
       {
         get
          {
            return userID;
          }
       }
       private void Form2_Load(object sender, EventArgs e)
       {
            Form1 f= new Form1();
            UserID = f.getUSERID();
       }
 
