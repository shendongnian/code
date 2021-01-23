    static Random cards = new Random();
    private void button1_Click(object sender, EventArgs e)
        {
            
            card = cards.Next(0, 9);
            switch (card)
            {
                case 0:
                    pictureBox1.Image = Properties.Resources.king_d;
                    pictureBox2.Image = Properties.Resources.jack_s;
                    break;
                case 1:
                    pictureBox1.Image = Properties.Resources.ace_c;
                    pictureBox2.Image = Properties.Resources.ten_d;
                    break;
            }
        }
    }
