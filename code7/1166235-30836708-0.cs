            List<WebControl> list = new List<WebControl>(); //in your case, it might be List<Control>
            
            Label lb1, title;
            
            lb1 = new Label();
             title = new Label();
                lb1.Text = "Test Label Control1";
                title.Text = "Test Title Label Control";
               p1.Controls.Add(lb1);
                p1.Controls.Add(title);
                list.Add(p1);
            
        }
