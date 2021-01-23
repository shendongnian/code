        private void b_click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black; //First color
            new System.Threading.Tasks.Task(() => PictureBoxTimeoutt(1000)).Start(); //miliseconds until change
        }
        public void PictureBoxTimeout(int delay)
        {
            System.Threading.Thread.Sleep(delay);
            Invoke((MethodInvoker)delegate
            {
                pictureBox1.BackColor = Color.White; //Second color
            };
        }
  
          
