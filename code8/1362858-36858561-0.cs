      public partial class GeneralInputForm : Form
      {
          // Returns true if this text is valid for a textbox
          protected virtual bool IsValid(string text)
          {
              return true;                    // default behaviour
          }
          private void button1_Click(object sender, EventArgs e)
          {
              if (IsValid(textBox1.Text))
              {
                  result = textBox1.Text;     // ok
                  Close();
              }
              else
              {
                  // Show error message
              }
          }
      }
