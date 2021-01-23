    public class AnswerForm
            {
                public static int no;
                private RadioButton[] rbuttons;
                private RadioButton[] checkboxes;
                
                public AnswerForm()
                {
                    no=0;
                    rbuttons = new RadioButton[] 
                    {
                        radioButton1,radioButton2,radioButton3,radioButton4,radioButton5
                    };
                    checkboxes = new CheckBox[]
                    {
                        checkBox1,checkBox2,checkBox3,checkBox4,checkBox5,checkBox6
                    };
                }
                public void AddRadio(string s)
                {
                    rbuttons[no++].Text=s;
                }
                public string AddBox(string s)
                {
                    checkboxes[no++].Text=s;
                }
            }
