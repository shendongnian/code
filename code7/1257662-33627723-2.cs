            private void button1_Click(object sender, EventArgs e)
        {
            var request1 = WebRequest.Create("http://i.imgur.com/ZkWyBo5.jpg?2");
            var request2 = WebRequest.Create("http://i.imgur.com/ZkWyBo5.jpg?2");
            var request3 = WebRequest.Create("http://i.imgur.com/ZkWyBo5.jpg?2");
            using (var response1 = request1.GetResponse())
            {
                using (var stream1 = response1.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream1);
                }
            }
            using (var response2 = request2.GetResponse())
            {
                using (var stream2 = response2.GetResponseStream())
                {
                    pictureBox2.Image = Bitmap.FromStream(stream2);
                }
            }
            using (var response3 = request3.GetResponse())
            {
                using (var stream3 = response3.GetResponseStream())
                {
                    pictureBox3.Image = Bitmap.FromStream(stream3);
                }
            }
        }
