      private void Form2_Load(object sender, EventArgs e){ 
        // Initial creation
        Button button = new Button() {
          Location = new Point(200, 30),
          Text = "Off",
          BackColor = Color.Red,  
          Parent = this,
        };
    
        // Toggle on click (when clicked change On -> Off -> On ...)
        button.Click += (s, ev) => {
          Button b = sender as Button;
    
          if (b.Text == "On") {
            // when "On" change to "Off"
            b.Text = "Off";
            b.BackColor = Color.Red;
          }
          else {
            b.Text = "On";
            b.BackColor = Color.Green;
          } 
        };
      }
