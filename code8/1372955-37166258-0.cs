                int x = 4;
                int y = 4;
                foreach (DataRow dt in YourDataTable.Rows)
                {
                    x = 4;
                    y = panel1 .Controls.Count * 20;
                  CheckBox ck=new CheckBox() ;
                    ck.Text =dt[2].ToString ();
                    //ck.Height = 10;
                    ck.Location = new Point(x, y);
                    Form1.Controls .Add (ck);
                }
