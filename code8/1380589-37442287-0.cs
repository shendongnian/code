       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
             InitLabel();
          }
          private void InitLabel()
          {
             Screen userScreen = Screen.PrimaryScreen;
             int screenWidth = userScreen.WorkingArea.Width;
             int screenHeight = userScreen.WorkingArea.Height;
             this.Width = screenWidth;
             this.Height = screenHeight;
             // I added the following 2 lines because the form was below the task bar
             this.StartPosition = FormStartPosition.Manual;
             this.Location = new Point(0,0);
             Label lblPaddle = new Label();
             lblPaddle.Name = "lblPaddle";
             lblPaddle.BackColor = Color.White;
             lblPaddle.BorderStyle = BorderStyle.FixedSingle;
             int lblPaddleWidth = (int)(screenWidth * 0.15);
             int lblPaddleHeight = lblPaddle.Height;
             int lblPaddleXCoord = (screenWidth / 2) - (lblPaddleWidth / 2);
             int lblPaddleYCoord = screenHeight - lblPaddleHeight - (int)(screenHeight * 0.1);
             lblPaddle.SetBounds(lblPaddleXCoord, lblPaddleYCoord, lblPaddleWidth, lblPaddleHeight);
             this.Controls.Add(lblPaddle);
          }
       }
