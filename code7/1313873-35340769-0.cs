     TextBox[] array = new TextBox[10];int count=0;
            for (int i = 0; i <= 45;i+=5 )
            {
                TextBox textBox = new TextBox()
                {
                    
                    Name = "txt_" + count,
                    Margin = new System.Windows.Forms.Padding(10+i,15+i,0,0),
                    
                    Text="Hello "+count,
                    Height = 10,
                    Width = 100
                };
                array[count++] = textBox;
            }
            for (int i = 0; i < array.Length;i++ )
            {
                panel1.Controls.Add(array[i]);
            }
               (panel1.Controls.Find("txt_0", false)[0]).Visible = false;
