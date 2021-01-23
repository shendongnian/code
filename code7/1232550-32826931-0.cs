     CheckBox[] checkBox1 = new CheckBox[5];
                checkBox1 [0] = checkBoxA;
                checkBox1 [1] = checkBoxB;
                checkBox1 [2] = checkBoxC;
                checkBox1 [3] = checkBoxD;
                checkBox1 [4] = checkBoxE;
     
                foreach(CheckBox items in checkBox1 )
                {
                    if (!items.Checked)
                    {
                        items.Enabled = false;
                    }
                }
