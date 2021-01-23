      Thread thread = new Thread(NewMethod);
            thread.Start();
     private void NewMethod()
        {
            for (int i = 0; i < sizes - 2; i++)
            {
                if (pictureBox1.Image != null)
                {
                    trackBar1.Value = trackBar1.Value + 1;
                    DisplayImage(_image);
                }
            }
        }
