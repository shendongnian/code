                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                if (e.NewValue + panel1.Width > panel1.HorizontalScroll.Maximum)
                    MessageBox.Show("End of Horizontal Scroll");
            }
            else
            {
                if (e.NewValue + panel1.Height > panel1.VerticalScroll.Maximum)
                    MessageBox.Show("End of Vertical Scroll");
            }
