    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){
         switch (comboBox1.SelectedItem.ToString())
          {
              case "Distance":
                  panel1.Visible = true;   
              break;
              case "Time":
              panel1.Visible = false;
              break;
              case "Velocity":
              panel1.Visible = true;
              break;
              default:
              MessageBox.Show("Default");
              break;
           }
     }
