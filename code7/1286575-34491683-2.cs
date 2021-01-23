    private static void GenerateButton(List<ButtonsDetails> details)
            {
                foreach (var item in details)
                {
                    Button b = new Button();
                    b.Click += (o, k) =>
                    {
                        textBox1.Text = item.Text
                        pictureBox1.Image = item.imgsource
                    };
                }
            }
   
     
