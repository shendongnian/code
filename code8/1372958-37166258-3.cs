                int x = 4;
                int y = 4;
                foreach (DataRow dt in YourDataTable.Rows)
                {
                    x = 4;
                    y = panel1 .Controls.Count * 20;
                  CheckBox ck=new CheckBox() ;
                    ck.Text =dt[2].ToString ();
                  
                     ck.Width = 450;  //  determine the width to fit 3 columns
                    ck.Location = new Point(x, y);
                    ck.CheckedChanged += new System.EventHandler(MyEven);   
                    Form1.Controls .Add (ck);
                }
