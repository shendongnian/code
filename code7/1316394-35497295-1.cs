    public void update(Position k, List<Position> p)
        {
            PictureBox p1 = this.Controls.Find("/* the picturebox name*/", true).FirstOrDefault() as PictureBox;
            PictureBox p2 = this.Controls.Find("/* the picturebox name*/", true).FirstOrDefault() as PictureBox;
            PictureBox p3 = this.Controls.Find("/* the picturebox name*/", true).FirstOrDefault() as PictureBox;
            PictureBox p4 = this.Controls.Find("/* the picturebox name*/", true).FirstOrDefault() as PictureBox;
            PictureBox p5 = this.Controls.Find("/* the picturebox name*/", true).FirstOrDefault() as PictureBox;
            this.board.Controls.Remove(p1);
            this.board.Controls.Remove(p2);
            this.board.Controls.Remove(p3);
            this.board.Controls.Remove(p4);
            this.board.Controls.Remove(p5);
            
            //p1_picturebox.Visible = false;
            //p2_picturebox.Visible = false;
            //p3_picturebox.Visible = false;
            //p4_picturebox.Visible = false;
            //p5_picturebox.Visible = false;
            // Load images in new positions            
            //this.board.Controls.Add(k_picturebox, k.col, knight.row);
            this.board.Controls.Add(p1, p[0].col, p[0].row);
            this.board.Controls.Add(p2, p[1].col, p[1].row);
            this.board.Controls.Add(p3, p[2].col, p[2].row);
            this.board.Controls.Add(p4, p[3].col, p[3].row);
            this.board.Controls.Add(p5, p[4].col, p[4].row);
            //alternatively for the whole above code you may optimize like below.
            int i = 0;
            for(Control c in PictureBoxList)    //PictureBoxList is retrieved as List<Control>
            {
                PictureBox p1 = this.Controls.Find(c.Name, true).FirstOrDefault() as PictureBox;
                p1.Name = c.Name;   //assign new name from the same list which contains pictureboxes and can get name by using c.Name
                this.board.Controls.Remove(p1);
                this.board.Controls.Add(p1, p[i].col, p[i].row);
                i++;
            }
            ------UPDATED-------- -
            this.Invalidate();
            Thread.Sleep(3000);
        }
